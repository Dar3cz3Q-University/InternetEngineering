using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using ErrorOr;
using MediatR;

namespace Core.Application.Users.Commands.UpdateMaxSearchDistance
{
    public class UpdateMaxSearchDistanceCommandHandler
        : IRequestHandler<UpdateMaxSearchDistanceCommand, ErrorOr<Updated>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserContextService _ctxService;

        public UpdateMaxSearchDistanceCommandHandler(
            IUserRepository userRepository,
            IUserContextService ctxService)
        {
            _userRepository = userRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<Updated>> Handle(
            UpdateMaxSearchDistanceCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _ctxService.GetUserId();

            var userResult = await _userRepository.GetByIdAsync(userId);

            if (userResult.IsError)
                throw new ApplicationException("Failed to retrieve user from database.");

            var user_ = userResult.Value;

            user_.UpdateMaxSearchDistance(request.MaxSearchDistance);

            var result = await _userRepository.UpdateAsync(user_);

            if (result.IsError)
                throw new ApplicationException("Failed to update user in database.");

            return Result.Updated;
        }
    }
}
