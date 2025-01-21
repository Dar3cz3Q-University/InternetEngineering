using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Application.Restaurants.Common;
using Core.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurants
{
    public class GetRestaurantsQueryHandler :
        IRequestHandler<GetRestaurantsQuery, ErrorOr<List<RestaurantDTO>>>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserContextService _ctxService;

        public GetRestaurantsQueryHandler(
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository,
            IUserContextService ctxService)
        {
            _restaurantRepository = restaurantRepository;
            _userRepository = userRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<List<RestaurantDTO>>> Handle(
            GetRestaurantsQuery request,
            CancellationToken cancellationToken)
        {
            var restaurants = await _restaurantRepository.GetAllFilteredByCategoryAsync(request.CategoriesIds);

            if (request.Latitude is null || request.Longitude is null)
                return restaurants.Value.ConvertAll(r => new RestaurantDTO(r, null));

            UserId id = _ctxService.GetUserId();

            var user = await _userRepository.GetByIdAsync(id);

            var maxDistance = user.Value.MaxSearchDistance;

            var nearbyRestaurants = restaurants.Value
                .Select(r => new
                {
                    Restaurant = r,
                    Distance = r.Location.CalculateDistance(
                        (double)request.Latitude,
                        (double)request.Longitude)
                })
                .Where(x => x.Distance <= maxDistance)
                .Select(x => new RestaurantDTO(x.Restaurant, x.Distance))
                .OrderBy(dto => dto.Distance ?? double.MaxValue)
                .ToList();

            return nearbyRestaurants;
        }
    }
}