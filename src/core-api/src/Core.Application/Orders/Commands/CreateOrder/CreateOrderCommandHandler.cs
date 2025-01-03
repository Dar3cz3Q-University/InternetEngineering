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

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Order>> Handle(
            CreateOrderCommand command,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var order = Order.Create(
                command.UserId,
                command.RestaurantId,
                command.AddressId,
                command.ItemsIds);

            return _orderRepository.Add(order);
        }
    }
}