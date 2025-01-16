using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Restaurants.Common;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurant
{
    public class GetRestaurantQueryHandler :
        IRequestHandler<GetRestaurantQuery, ErrorOr<RestaurantDTO>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public GetRestaurantQueryHandler(
            IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ErrorOr<RestaurantDTO>> Handle(
            GetRestaurantQuery request,
            CancellationToken cancellationToken)
        {
            var restaurantResult = await _restaurantRepository.GetByIdAsync(request.RestaurantId);

            // TODO: Check for more specific error
            if (restaurantResult.IsError)
                return Errors.Restaurant.NotFound(request.RestaurantId);

            var restaurant = restaurantResult.Value;

            if (request.Latitude is null || request.Longitude is null)
                return new RestaurantDTO(restaurant, null);

            var distance = restaurant.Location.CalculateDistance(
                (double)request.Latitude,
                (double)request.Longitude);

            return new RestaurantDTO(restaurant, distance);
        }
    }
}