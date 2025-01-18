using Core.Application.Common.Commands;
using Core.Application.Restaurants.Common;
using Core.Domain.CategoryAggregate.ValueObjects;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Restaurants.Commands.CreateRestaurant
{
    public record CreateRestaurantCommand(
        string Name,
        string Description,
        IFormFile Image,
        List<CategoryId> Categories,
        CreateAddressCommand Location,
        CreateContactInfoCommand ContactInfo,
        CreateOpeningHoursCommand OpeningHours) : IRequest<ErrorOr<RestaurantDTO>>;
}