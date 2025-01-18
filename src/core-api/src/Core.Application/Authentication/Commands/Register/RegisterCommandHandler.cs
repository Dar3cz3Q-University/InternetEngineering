using Core.Application.Authentication.Common;
using Core.Application.Common.Config;
using Core.Application.Common.Interfaces.Authentication;
using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.Common.Errors;
using Core.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Core.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IImageSaver _saver;
        private readonly IAddressService _addressService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IImageSaver saver,
            IAddressService addressService,
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _saver = saver;
            _addressService = addressService;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<ErrorOr<AuthenticationDTO>> Handle(
            RegisterCommand command,
            CancellationToken cancellationToken)
        {
            var userResult = await _userRepository.GetByEmailAsync(command.Email);

            // TODO: Check for more specific error
            if (!userResult.IsError)
                return Errors.User.DuplicateEmail;

            var address = await _addressService.CreateAddressAsync(command.Address);

            var imageUrl = await _saver.Save(command.Image, StaticFilesSettings.USERS, cancellationToken);

            var user = User.CreateUnique(
                imageUrl,
                command.FirstName,
                command.LastName,
                command.Email,
                command.PhoneNumber,
                _passwordHasher.HashPassword(command.Password),
                command.MaxSearchDistance,
                command.UserRole,
                address);

            var result = await _userRepository.AddAsync(user);

            // TODO: Check for more specific error
            if (result.IsError)
                throw new ApplicationException("Failed to add user to database.");

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationDTO(user, token);
        }
    }
}