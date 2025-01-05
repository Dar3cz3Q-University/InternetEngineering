using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Validation;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Common.Behaviors
{
    public class UserExistenceBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IUserRepository _userRepository;

        public UserExistenceBehavior(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (request is IRequireUserValidation userRequest)
            {
                var userResult = await _userRepository.GetByIdAsync(userRequest.UserId);

                // TODO: Check for more specific error
                if (userResult.IsError)
                {
                    return (dynamic)Errors.User.NotFound(userRequest.UserId);
                }
            }

            return await next();
        }
    }
}