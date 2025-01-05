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

        public async Task<ErrorOr<Menu>> Handle(
            GetMenuQuery request,
            CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.GetByIdAsync(request.MenuId);

            // TODO: Check for more specific error
            if (menu.IsError)
            {
                return Errors.Menu.NotFound(request.MenuId);
            }

            return menu;
        }
    }
}