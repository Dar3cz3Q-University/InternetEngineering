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
        private readonly IAddressRepository _addressRepository;

        public GetOrderQueryHandler(
            IOrderRepository orderRepository,
            IAddressRepository addressRepository)
        {
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
        }

        public async Task<ErrorOr<Order>> Handle(
            GetOrderQuery request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            // TODO: Check for more specific error
            if (order.IsError)
            {
                return Errors.Order.NotFound(request.OrderId);
            }

            return order;
        }
    }
}