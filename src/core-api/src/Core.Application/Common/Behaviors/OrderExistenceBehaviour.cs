using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Common.Behaviors
{
    public class OrderExistenceBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IOrderRepository _orderRepository;

        public OrderExistenceBehavior(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (request is IRequireOrderValidation orderRequest)
            {
                var order = await _orderRepository.GetByIdAsync(orderRequest.OrderId);

                // TODO: Check for more specific error
                if (order.IsError)
                {
                    return (dynamic)Errors.Order.NotFound(orderRequest.OrderId);
                }
            }

            return await next();
        }
    }
}