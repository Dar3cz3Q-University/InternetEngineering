using Core.Application.Common.Commands;
using Core.Domain.RestaurantAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Commands.CreateRestaurant
{
    public record CreateRestaurantCommand(
        string Name,
        CreateAddressCommand Location,
        string Description,
        CreateContactInfoCommand ContactInfo,
        CreateOpeningHoursCommand OpeningHours) : IRequest<ErrorOr<Restaurant>>;
}