using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQueryHandler :
        IRequestHandler<GetOrdersQuery, ErrorOr<List<Order>>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ErrorOr<List<Order>>> Handle(
            GetOrdersQuery request,
            CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllAsync();
        }
    }
}