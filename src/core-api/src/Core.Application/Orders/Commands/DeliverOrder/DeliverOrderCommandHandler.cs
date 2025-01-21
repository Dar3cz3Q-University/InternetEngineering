using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.DeliverOrder
{
    public class DeliverOrderCommandHandler
        : IRequestHandler<DeliverOrderCommand, ErrorOr<Updated>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserContextService _ctxService;

        public DeliverOrderCommandHandler(
            IOrderRepository orderRepository,
            IUserContextService ctxService)
        {
            _orderRepository = orderRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<Updated>> Handle(
            DeliverOrderCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _ctxService.GetUserId();

            var orderResult = await _orderRepository.GetActiveForCourier(userId);

            if (orderResult.IsError)
                throw new ApplicationException("Could not retrieve order from database.");

            var order = orderResult.Value;

            if (order.OrderStatus == Domain.OrderAggregate.OrderStatus.Delivered)
                return Errors.Order.AlreadyDelivered(order.Id);

            order.SetOrderStatus(Domain.OrderAggregate.OrderStatus.Delivered);

            await _orderRepository.UpdateAsync(order);

            return Result.Updated;
        }
    }
}
