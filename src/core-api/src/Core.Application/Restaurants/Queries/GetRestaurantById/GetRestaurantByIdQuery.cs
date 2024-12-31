using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Queries.GetRestaurantById
{
    public record GetRestaurantByIdQuery(
        RestaurantId Id) : IRequest<ErrorOr<Restaurant>>;
}