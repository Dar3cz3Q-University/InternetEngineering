using Core.Application.Authentication.Common;
using Core.Application.Common.Interfaces.Authentication;
using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationDTO>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationDTO>> Handle(
            LoginQuery query,
            CancellationToken cancellationToken)
        {
            var userResult = await _userRepository.GetByEmailAsync(query.Email);

            // TODO: Check for more specific error
            if (userResult.IsError)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var user = userResult.Value;

            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationDTO(user, token);
        }
    }
}