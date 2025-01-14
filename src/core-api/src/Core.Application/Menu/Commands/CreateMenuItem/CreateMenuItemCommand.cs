using Core.Application.Common.Commands;
using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Menu.Commands.CreateMenuItem
{
    public record CreateMenuItemCommand(
        RestaurantId RestaurantId,
        MenuSectionId MenuSectionId,
        string Name,
        string Description,
        CreateMoneyCommand Price) : IRequest<ErrorOr<MenuItem>>;
}