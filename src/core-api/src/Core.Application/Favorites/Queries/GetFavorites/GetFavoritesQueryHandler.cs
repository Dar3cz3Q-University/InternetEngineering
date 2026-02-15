using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using ErrorOr;
using MediatR;

namespace Core.Application.Favorites.Queries.GetFavorites
{
    public class GetFavoritesQueryHandler
        : IRequestHandler<GetFavoritesQuery, ErrorOr<List<Guid>>>
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IUserContextService _ctxService;

        public GetFavoritesQueryHandler(
            IFavoriteRepository favoriteRepository,
            IUserContextService ctxService)
        {
            _favoriteRepository = favoriteRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<List<Guid>>> Handle(
            GetFavoritesQuery request,
            CancellationToken cancellationToken)
        {
            var userId = _ctxService.GetUserId();
            var favoriteIds = await _favoriteRepository.GetUserFavoriteIdsAsync(userId);
            return favoriteIds;
        }
    }
}