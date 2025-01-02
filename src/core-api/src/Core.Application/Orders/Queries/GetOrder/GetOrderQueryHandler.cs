using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using Core.Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler :
        IRequestHandler<GetOrderQuery, ErrorOr<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Order>> Handle(
            GetOrderQuery request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var order = _orderRepository.GetById(request.OrderId);

            if (order is null)
            {
                return Errors.Order.NotFound(request.OrderId);
            }

            return order;
        }
    }
}