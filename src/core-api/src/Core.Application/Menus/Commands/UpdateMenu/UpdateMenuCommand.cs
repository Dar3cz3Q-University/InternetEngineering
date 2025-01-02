using Core.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Commands.UpdateMenu
{
    // TODO: [Create update command handlers #42]
    public record UpdateMenuCommand() : IRequest<ErrorOr<Menu>>;
}