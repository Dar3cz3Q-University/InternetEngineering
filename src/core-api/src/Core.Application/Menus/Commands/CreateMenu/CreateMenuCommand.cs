using Core.Application.Common.Commands;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.MenuAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(
        string Name,
        string Description,
        RestaurantId RestaurantId,
        List<CreateMenuSectionComand> Sections) : IRequest<ErrorOr<Menu>>, IRequireRestaurantValidation;

    public record CreateMenuSectionComand(
        string Name,
        string Description,
        List<CreateMenuItemCommand> Items);

    public record CreateMenuItemCommand(
        string Name,
        string Description,
        CreateMoneyCommand Price,
        bool IsAvailable);
}