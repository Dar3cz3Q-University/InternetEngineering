using Core.Application.Authentication.Common;
using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler
        : IRequestHandler<GetUserQuery, ErrorOr<AuthenticationDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserContextService _ctxService;

        public GetUserQueryHandler(
            IUserRepository userRepository,
            IUserContextService ctxService)
        {
            _userRepository = userRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<AuthenticationDTO>> Handle(
            GetUserQuery request,
            CancellationToken cancellationToken)
        {
            var userId = _ctxService.GetUserId();

            var userResult = await _userRepository.GetByIdAsync(userId);

            if (userResult.IsError)
                throw new ApplicationException("Could not retrieve user from database.");

            return new AuthenticationDTO(
                userResult.Value,
                "",
                new DateTime());
        }
    }
}