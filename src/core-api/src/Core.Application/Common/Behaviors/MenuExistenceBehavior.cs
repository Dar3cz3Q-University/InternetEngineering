using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Common.Behaviors
{
    public class MenuExistenceBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IMenuRepository _menuRepository;

        public MenuExistenceBehavior(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (request is IRequireMenuValidation menuRequest)
            {
                var menu = await _menuRepository.GetByIdAsync(menuRequest.MenuId);

                // TODO: Check for more specific error
                if (menu.IsError)
                {
                    return (dynamic)Errors.Menu.NotFound(menuRequest.MenuId);
                }
            }

            return await next();
        }
    }
}