using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.Entities;
using Core.Domain.UserAggregate.ValueObjects;
using ErrorOr;

namespace Core.Application.Common.Interfaces.Persistance
{
    public interface IFavoriteRepository
    {
        Task<ErrorOr<Created>> AddAsync(FavoriteRestaurant favorite);
        Task<ErrorOr<Deleted>> RemoveAsync(UserId userId, RestaurantId restaurantId);
        Task<bool> ExistsAsync(UserId userId, RestaurantId restaurantId);
        Task<List<Guid>> GetUserFavoriteIdsAsync(UserId userId);
    }
}