using Core.Application.Common.Interfaces.Persistance;
using Core.Application.Common.Interfaces.Services;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.Entities;
using ErrorOr;
using MediatR;

namespace Core.Application.Favorites.Commands.AddFavorite
{
    public class AddFavoriteCommandHandler
        : IRequestHandler<AddFavoriteCommand, ErrorOr<Created>>
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IUserContextService _ctxService;

        public AddFavoriteCommandHandler(
            IFavoriteRepository favoriteRepository,
            IRestaurantRepository restaurantRepository,
            IUserContextService ctxService)
        {
            _favoriteRepository = favoriteRepository;
            _restaurantRepository = restaurantRepository;
            _ctxService = ctxService;
        }

        public async Task<ErrorOr<Created>> Handle(
            AddFavoriteCommand request,
            CancellationToken cancellationToken)
        {
            var userId = _ctxService.GetUserId();
            var restaurantId = RestaurantId.Create(request.RestaurantId);

            var restaurantResult = await _restaurantRepository.GetByIdAsync(restaurantId);
            if (restaurantResult.IsError)
                return restaurantResult.Errors;

            var favorite = FavoriteRestaurant.Create(userId, restaurantId);
            var result = await _favoriteRepository.AddAsync(favorite);

            if (result.IsError)
                return result.Errors;

            return Result.Created;
        }
    }
}