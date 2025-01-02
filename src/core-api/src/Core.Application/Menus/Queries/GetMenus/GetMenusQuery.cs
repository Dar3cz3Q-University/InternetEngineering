using Core.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Queries.GetMenus
{
    public record GetMenusQuery() : IRequest<ErrorOr<List<Menu>>>;
}