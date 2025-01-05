using Core.Application.Authentication.Common;
using Core.Application.Common.Interfaces.Authentication;
using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Core.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationDTO>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public LoginQueryHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;

            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
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

            if (!_passwordHasher.VerifyPassword(user.Password, query.Password))
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationDTO(user, token);
        }
    }
}