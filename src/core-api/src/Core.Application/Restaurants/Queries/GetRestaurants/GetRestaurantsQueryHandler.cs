using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.RestaurantAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurants
{
    public class GetRestaurantsQueryHandler :
        IRequestHandler<GetRestaurantsQuery, ErrorOr<List<Restaurant>>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public GetRestaurantsQueryHandler(
            IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ErrorOr<List<Restaurant>>> Handle(
            GetRestaurantsQuery request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return _restaurantRepository.GetAll();
        }
    }
}
