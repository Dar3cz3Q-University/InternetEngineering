using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Commands.UpdateMenu
{
    // TODO: [Create update command handlers #42]
    public class UpdateMenuCommandHandler :
        IRequestHandler<UpdateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public UpdateMenuCommandHandler(
            IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Menu>> Handle(
            UpdateMenuCommand request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            throw new NotImplementedException();
        }
    }
}
