using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.TakeOrder
{
    public class TakeOrderCommandHandler
        : IRequestHandler<TakeOrderCommand, ErrorOr<Updated>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserContextService _ctxService;

        public TakeOrderCommandHandler(
            IOrderRepository orderRepository,
            IUserContextService ctxService)
        {
            _orderRepository = orderRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<Updated>> Handle(
            TakeOrderCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _ctxService.GetUserId();

            var orderResult = await _orderRepository.GetByIdAsync(request.OrderId);

            if (orderResult.IsError)
                throw new ApplicationException("Could not retrieve order from database.");

            var order = orderResult.Value;

            if (order.OrderStatus == Domain.OrderAggregate.OrderStatus.Delivered && order.OrderStatus == Domain.OrderAggregate.OrderStatus.InDelivery)
                return Errors.Order.AlreadyDelivered(order.Id);

            order.SetOrderStatus(Domain.OrderAggregate.OrderStatus.InDelivery);
            order.SetCourierId(userId);

            await _orderRepository.UpdateAsync(order);

            return Result.Updated;
        }
    }
}