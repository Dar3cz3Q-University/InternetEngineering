using Core.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(
        string Name,
        string Description,
        string RestaurantId,
        List<CreateMenuSectionComand> Sections) : IRequest<ErrorOr<Menu>>;

    public record CreateMenuSectionComand(
        string Name,
        string Description,
        List<CreateMenuItemCommand> Items);

    public record CreateMenuItemCommand(
        string Name,
        string Description,
        CreateMoneyCommand Price,
        bool IsAvailable);

    public record CreateMoneyCommand(
        decimal Amount,
        string Currency);
}
