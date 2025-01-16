using Core.Application.Restaurants.Common;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurants
{
    public record GetRestaurantsQuery(
        double? Longitude,
        double? Latitude) : IRequest<ErrorOr<List<RestaurantDTO>>>;
}