using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Core.Application.Favorites.Commands.RemoveFavorite
{
    public class RemoveFavoriteCommandHandler
        : IRequestHandler<RemoveFavoriteCommand, ErrorOr<Deleted>>
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IUserContextService _ctxService;

        public RemoveFavoriteCommandHandler(
            IFavoriteRepository favoriteRepository,
            IUserContextService ctxService)
        {
            _favoriteRepository = favoriteRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            RemoveFavoriteCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _ctxService.GetUserId();
            var restaurantId = RestaurantId.Create(request.RestaurantId);

            var result = await _favoriteRepository.RemoveAsync(userId, restaurantId);

            if (result.IsError)
                return result.Errors;

            return Result.Deleted;
        }
    }
}
