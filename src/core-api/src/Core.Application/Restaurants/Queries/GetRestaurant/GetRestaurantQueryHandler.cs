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

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Restaurant>> Handle(
            GetRestaurantQuery request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var restaurant = _restaurantRepository.GetById(request.RestaurantId);

            if (restaurant is null)
            {
                return Errors.Restaurant.NotFound(request.RestaurantId);
            }

            return restaurant;
        }
    }
}