using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.CategoryAggregate;
using Core.Domain.CategoryAggregate.ValueObjects;
using Core.Domain.Common.Errors;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MainDbContext _dbContext;

        public CategoryRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<Created>> AddAsync(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);

            await _dbContext.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return Result.Created;
        }

        public async Task<ErrorOr<Deleted>> DeleteByIdAsync(CategoryId id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            if (category is null)
                return Errors.Category.NotFound(id);

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return Result.Deleted;
        }

        public async Task<ErrorOr<List<Category>>> GetAllAsync()
        {
            return await _dbContext.Set<Category>().ToListAsync();
        }

        public async Task<ErrorOr<Category>> GetByIdAsync(CategoryId id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            if (category is null)
                return Errors.Category.NotFound(id);

            return category;
        }

        public async Task<ErrorOr<Updated>> UpdateAsync(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);

            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();

            return Result.Updated;
        }
    }
}