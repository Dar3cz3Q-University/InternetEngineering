using Core.Application.Restaurants.Common;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurant
{
    public record GetRestaurantQuery(
        RestaurantId RestaurantId,
        double? Latitude,
        double? Longitude) : IRequest<ErrorOr<RestaurantDTO>>;
}