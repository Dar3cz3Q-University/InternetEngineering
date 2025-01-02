using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Queries.GetMenu
{
    public record GetMenuQuery(
        MenuId MenuId) : IRequest<ErrorOr<Menu>>;
}
