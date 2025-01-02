using Core.Application.Authentication.Common;
using Core.Application.Common.Interfaces.Authentication;
using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using Core.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = User.CreateUnique(
                command.FirstName,
                command.LastName,
                command.Email,
                command.PhoneNumber,
                command.Password,
                command.UserRole);

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}