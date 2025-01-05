using Core.Application.Common.Interfaces.Validation;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Restaurants.Commands.DeleteRestaurant
{
    public record DeleteRestaurantCommand(
        RestaurantId RestaurantId) : IRequest<ErrorOr<Deleted>>, IRequireRestaurantValidation;
}