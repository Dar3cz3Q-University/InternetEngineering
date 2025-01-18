using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.Common.Errors;
using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MainDbContext _dbContext;

        public MenuRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<Created>> AddAsync(Menu menu)
        {
            ArgumentNullException.ThrowIfNull(menu);

            await _dbContext.AddAsync(menu);
            await _dbContext.SaveChangesAsync();

            return Result.Created;
        }

        public async Task<ErrorOr<Deleted>> DeleteByIdAsync(MenuId id)
        {
            var menu = await _dbContext.Menus.FindAsync(id);

            if (menu is null)
                return Errors.Menu.NotFound(id);

            _dbContext.Menus.Remove(menu);
            await _dbContext.SaveChangesAsync();

            return Result.Deleted;
        }

        public async Task<ErrorOr<List<Menu>>> GetAllAsync()
        {
            return await _dbContext.Set<Menu>().ToListAsync();
        }

        public async Task<ErrorOr<Menu>> GetByIdAsync(MenuId id)
        {
            var menu = await _dbContext.Menus.FindAsync(id);

            if (menu is null)
                return Errors.Menu.NotFound(id);

            return menu;
        }

        public async Task<ErrorOr<Updated>> UpdateAsync(Menu menu)
        {
            ArgumentNullException.ThrowIfNull(menu);

            _dbContext.Menus.Update(menu);
            await _dbContext.SaveChangesAsync();

            return Result.Updated;
        }
    }
}