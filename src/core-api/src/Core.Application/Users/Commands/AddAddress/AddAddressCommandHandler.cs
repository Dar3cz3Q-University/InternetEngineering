using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using ErrorOr;
using MediatR;

namespace Core.Application.Users.Commands.AddAddress
{
    public class AddAddressCommandHandler
        : IRequestHandler<AddAddressCommand, ErrorOr<Updated>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserContextService _ctxService;
        private readonly IAddressService _addressService;

        public AddAddressCommandHandler(
            IUserRepository userRepository,
            IUserContextService ctxService,
            IAddressService addressService)
        {
            _userRepository = userRepository;
            _ctxService = ctxService;
            _addressService = addressService;
        }

        public async Task<ErrorOr<Updated>> Handle(
            AddAddressCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _ctxService.GetUserId();

            var userResult = await _userRepository.GetByIdAsync(userId);

            if (userResult.IsError)
                throw new ApplicationException("Failed to retrieve user from database.");

            var address = await _addressService.CreateAddressAsync(request.Address);

            var user_ = userResult.Value;

            user_.AddAddress(address);

            var result = await _userRepository.UpdateAsync(user_);

            if (result.IsError)
                throw new ApplicationException("Failed to update user in database.");

            return Result.Updated;
        }
    }
}