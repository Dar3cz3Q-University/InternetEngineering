using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Common.Behaviors
{
    public class ValidateMenuExistenceBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IMenuRepository _menuRepository;

        public ValidateMenuExistenceBehavior(IMenuRepository menuRepository)
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
                var menu = _menuRepository.GetById(menuRequest.MenuId);

                if (menu is null)
                {
                    return (dynamic)Errors.Menu.NotFound(menuRequest.MenuId);
                }
            }

            return await next();
        }
    }
}
