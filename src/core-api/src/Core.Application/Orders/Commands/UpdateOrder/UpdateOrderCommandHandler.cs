using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.UpdateOrder
{
    // TODO: [Create update command handlers #42]
    public class UpdateOrderCommandHandler :
        IRequestHandler<UpdateOrderCommand, ErrorOr<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Order>> Handle(
            UpdateOrderCommand request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            throw new NotImplementedException();
        }
    }
}
