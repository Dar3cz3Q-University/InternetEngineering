using Core.Application.Common.Interfaces.Persistance;
using ErrorOr;
using MediatR;

namespace Core.Application.Orders.Commands.DeleteOrder
{
    internal class DeleteOrderCommandHandler :
        IRequestHandler<DeleteOrderCommand, ErrorOr<Deleted>>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteOrderCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _orderRepository.DeleteByIdAsync(request.OrderId);

            // TODO: Check for more specific error
            if (result.IsError)
                throw new ApplicationException("Failed to remove order from database.");

            return Result.Deleted;
        }
    }
}