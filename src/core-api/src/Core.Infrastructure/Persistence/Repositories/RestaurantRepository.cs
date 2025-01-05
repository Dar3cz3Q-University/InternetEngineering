using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly MainDbContext _dbContext;

        public RestaurantRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<Created>> AddAsync(Restaurant restaurant)
        {
            ArgumentNullException.ThrowIfNull(restaurant);

            await _dbContext.AddAsync(restaurant);
            await _dbContext.SaveChangesAsync();

            return Result.Created;
        }

        public async Task<ErrorOr<Deleted>> DeleteByIdAsync(RestaurantId id)
        {
            var restaurant = await _dbContext.Restaurants.FindAsync(id);

            if (restaurant is null)
            {
                return Errors.Restaurant.NotFound(id);
            }

            _dbContext.Restaurants.Remove(restaurant);
            await _dbContext.SaveChangesAsync();

            return Result.Deleted;
        }

        public async Task<ErrorOr<List<Restaurant>>> GetAllAsync()
        {
            return await _dbContext.Set<Restaurant>().ToListAsync();
        }

        public async Task<ErrorOr<Restaurant>> GetByIdAsync(RestaurantId id)
        {
            var restaurant = await _dbContext.Restaurants.FindAsync(id);

            if (restaurant is null)
            {
                return Errors.Restaurant.NotFound(id);
            }

            return restaurant;
        }

        public async Task<ErrorOr<Updated>> UpdateAsync(Restaurant restaurant)
        {
            ArgumentNullException.ThrowIfNull(restaurant);

            _dbContext.Restaurants.Update(restaurant);
            await _dbContext.SaveChangesAsync();

            return Result.Updated;
        }
    }
}