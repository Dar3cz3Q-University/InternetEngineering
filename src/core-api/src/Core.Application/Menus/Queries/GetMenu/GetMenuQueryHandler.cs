using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using Core.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Queries.GetMenu
{
    public class GetMenuQueryHandler :
        IRequestHandler<GetMenuQuery, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public GetMenuQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Menu>> Handle(
            GetMenuQuery request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var menu = _menuRepository.GetById(request.MenuId);

            if (menu is null)
            {
                return Errors.Menu.NotFound(request.MenuId);
            }

            return menu;
        }
    }
}