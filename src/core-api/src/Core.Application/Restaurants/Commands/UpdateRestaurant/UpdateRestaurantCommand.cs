using Core.Domain.RestaurantAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Commands.UpdateRestaurant
{
    // TODO: [Create update command handlers #42]
    public record UpdateRestaurantCommand() : IRequest<ErrorOr<Restaurant>>;
}