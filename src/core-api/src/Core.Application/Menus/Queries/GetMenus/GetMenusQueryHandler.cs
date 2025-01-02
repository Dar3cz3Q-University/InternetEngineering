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

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<List<Menu>>> Handle(
            GetMenusQuery request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            return _menuRepository.All();
        }
    }
}
