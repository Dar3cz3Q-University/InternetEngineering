using Core.Domain.RestaurantAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurants
{
    public record GetRestaurantsQuery() : IRequest<ErrorOr<List<Restaurant>>>;
}