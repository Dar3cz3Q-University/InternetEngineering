using Core.Application.Common.Commands;
using Core.Domain.RestaurantAggregate;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Restaurants.Commands.CreateRestaurant
{
    public record CreateRestaurantCommand(
        string Name,
        string Description,
        IFormFile Image,
        CreateAddressCommand Location,
        CreateContactInfoCommand ContactInfo,
        CreateOpeningHoursCommand OpeningHours) : IRequest<ErrorOr<Restaurant>>;
}