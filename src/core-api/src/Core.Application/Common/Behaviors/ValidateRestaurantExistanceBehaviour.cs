using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Common.Behaviors
{
    public class ValidateRestaurantExistenceBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public ValidateRestaurantExistenceBehavior(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (request is IRequireRestaurantValidation restaurantRequest)
            {
                var restaurant = _restaurantRepository.GetById(restaurantRequest.RestaurantId);

                if (restaurant is null)
                {
                    return (dynamic)Errors.Restaurant.NotFound(restaurantRequest.RestaurantId);
                }
            }

            return await next();
        }
    }
}