using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Common.Behaviors
{
    public class RestaurantExistenceBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantExistenceBehavior(IRestaurantRepository restaurantRepository)
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
                var restaurant = await _restaurantRepository.GetByIdAsync(restaurantRequest.RestaurantId);

                // TODO: Check for more specific error
                if (restaurant.IsError)
                {
                    return (dynamic)Errors.Restaurant.NotFound(restaurantRequest.RestaurantId);
                }
            }

            return await next();
        }
    }
}