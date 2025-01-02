using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurant
{
    public record GetRestaurantQuery(
        RestaurantId RestaurantId) : IRequest<ErrorOr<Restaurant>>;
}
