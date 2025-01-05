using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using Core.Domain.RestaurantAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurant
{
    public class GetRestaurantQueryHandler :
        IRequestHandler<GetRestaurantQuery, ErrorOr<Restaurant>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public GetRestaurantQueryHandler(
            IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ErrorOr<Restaurant>> Handle(
            GetRestaurantQuery request,
            CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(request.RestaurantId);

            // TODO: Check for more specific error
            if (restaurant.IsError)
            {
                return Errors.Restaurant.NotFound(request.RestaurantId);
            }

            return restaurant;
        }
    }
}