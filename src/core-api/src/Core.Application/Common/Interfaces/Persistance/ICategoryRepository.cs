using Core.Domain.CategoryAggregate;
using Core.Domain.CategoryAggregate.ValueObjects;
using ErrorOr;

namespace Core.Application.Common.Interfaces.Persistance
{
    public interface ICategoryRepository
    {
        Task<ErrorOr<Created>> AddAsync(Category category);
        Task<ErrorOr<Deleted>> DeleteByIdAsync(CategoryId id);
        Task<ErrorOr<Category>> GetByIdAsync(CategoryId id);
        Task<ErrorOr<List<Category>>> GetAllAsync();
        Task<ErrorOr<Updated>> UpdateAsync(Category category);
    }
}