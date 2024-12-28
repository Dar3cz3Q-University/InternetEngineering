using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using Core.Domain.RestaurantAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler :
        IRequestHandler<GetRestaurantByIdQuery, ErrorOr<Restaurant>>
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public GetRestaurantByIdQueryHandler(
            IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ErrorOr<Restaurant>> Handle(
            GetRestaurantByIdQuery request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var restaurant = _restaurantRepository.Get(request.Id);

            if (restaurant is null)
            {
                return Errors.Restaurant.NotFound(request.Id);
            }

            return restaurant;
        }
    }
}
