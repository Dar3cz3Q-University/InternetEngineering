using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler :
        IRequestHandler<CreateOrderCommand, ErrorOr<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ErrorOr<Order>> Handle(
            CreateOrderCommand command,
            CancellationToken cancellationToken)
        {
            var order = Order.Create(
                command.UserId,
                command.RestaurantId,
                command.AddressId,
                command.ItemsIds);

            var result = await _orderRepository.AddAsync(order);

            // TODO: Check for more specific error
            if (result.IsError)
            {
                throw new ApplicationException("Failed to add order to database.");
            }

            return order;
        }
    }
}