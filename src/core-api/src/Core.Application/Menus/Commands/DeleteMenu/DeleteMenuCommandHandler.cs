using Core.Application.Common.Interfaces.Persistance;
using ErrorOr;
using MediatR;

namespace Core.Application.Menus.Commands.DeleteMenu
{
    public class DeleteMenuCommandHandler :
        IRequestHandler<DeleteMenuCommand, ErrorOr<Deleted>>
    {
        private readonly IMenuRepository _menuRepository;

        public DeleteMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteMenuCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _menuRepository.DeleteByIdAsync(request.MenuId);

            // TODO: Check for more specific error
            if (result.IsError)
            {
                throw new ApplicationException("Failed to remove menu from database.");
            }

            return Result.Deleted;
        }
    }
}