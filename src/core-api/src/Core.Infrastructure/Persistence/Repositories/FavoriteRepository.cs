using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.Entities;
using Core.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly MainDbContext _dbContext;

        public FavoriteRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<Created>> AddAsync(FavoriteRestaurant favorite)
        {
            ArgumentNullException.ThrowIfNull(favorite);

            var exists = await ExistsAsync(favorite.UserId, favorite.RestaurantId);
            if (exists)
                return Errors.Favorite.AlreadyExists(favorite.UserId, favorite.RestaurantId);

            await _dbContext.FavoriteRestaurants.AddAsync(favorite);
            await _dbContext.SaveChangesAsync();

            return Result.Created;
        }

        public async Task<ErrorOr<Deleted>> RemoveAsync(UserId userId, RestaurantId restaurantId)
        {
            var favorite = await _dbContext.FavoriteRestaurants
                .FirstOrDefaultAsync(f => f.UserId == userId && f.RestaurantId == restaurantId);

            if (favorite is null)
                return Errors.Favorite.NotFound(userId, restaurantId);

            _dbContext.FavoriteRestaurants.Remove(favorite);
            await _dbContext.SaveChangesAsync();

            return Result.Deleted;
        }

        public async Task<bool> ExistsAsync(UserId userId, RestaurantId restaurantId)
        {
            return await _dbContext.FavoriteRestaurants
                .AnyAsync(f => f.UserId == userId && f.RestaurantId == restaurantId);
        }

        public async Task<List<Guid>> GetUserFavoriteIdsAsync(UserId userId)
        {
            return await _dbContext.FavoriteRestaurants
                .Where(f => f.UserId == userId)
                .Select(f => f.RestaurantId.Value)
                .ToListAsync();
        }
    }
}
