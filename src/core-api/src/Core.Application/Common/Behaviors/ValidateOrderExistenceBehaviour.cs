using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Common.Behaviors
{
    public class ValidateOrderExistenceBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IOrderRepository _orderRepository;

        public ValidateOrderExistenceBehavior(IOrderRepository orderRepository)
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
                var order = _orderRepository.GetById(orderRequest.OrderId);

                if (order is null)
                {
                    return (dynamic)Errors.Order.NotFound(orderRequest.OrderId);
                }
            }

            return await next();
        }
    }
}