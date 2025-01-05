using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Queries.GetMenus
{
    internal class GetMenusQueryHandler :
        IRequestHandler<GetMenusQuery, ErrorOr<List<Menu>>>
    {
        private readonly IMenuRepository _menuRepository;

        public GetMenusQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<List<Menu>>> Handle(
            GetMenusQuery request,
            CancellationToken cancellationToken)
        {
            return await _menuRepository.GetAllAsync();
        }
    }
}