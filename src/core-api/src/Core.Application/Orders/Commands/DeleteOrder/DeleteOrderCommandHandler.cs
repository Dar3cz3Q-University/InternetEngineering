using Core.Application.Common.Interfaces.Persistance;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.DeleteOrder
{
    internal class DeleteOrderCommandHandler :
        IRequestHandler<DeleteOrderCommand, ErrorOr<Unit>>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Unit>> Handle(
            DeleteOrderCommand request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _orderRepository.Delete(request.OrderId);

            return Unit.Value;
        }
    }
}
