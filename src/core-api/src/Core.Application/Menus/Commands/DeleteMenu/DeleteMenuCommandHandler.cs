using Core.Application.Common.Interfaces.Persistance;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Commands.DeleteMenu
{
    public class DeleteMenuCommandHandler :
        IRequestHandler<DeleteMenuCommand, ErrorOr<Unit>>
    {
        private readonly IMenuRepository _menuRepository;

        public DeleteMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // TODO: [Change handlers to use async functions from repository #28]
        public async Task<ErrorOr<Unit>> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _menuRepository.Delete(request.MenuId);

            return Unit.Value;
        }
    }
}