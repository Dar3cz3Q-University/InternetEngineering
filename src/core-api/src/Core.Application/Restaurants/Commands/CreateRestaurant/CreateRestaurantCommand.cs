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

    public record CreateAddressCommand(
        string Street,
        string City,
        string PostalCode);

    public record CreateContactInfoCommand(
        string PhoneNumber,
        string Email);

    public record CreateOpeningHoursCommand(
        DateTime OpenTime,
        DateTime CloseTime);

    public record CreateMoneyCommand(
        decimal Amount,
        string Currency);
}
