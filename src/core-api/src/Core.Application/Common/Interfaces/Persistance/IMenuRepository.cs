using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;
using MenuEntity = Core.Domain.RestaurantAggregate.Entities;

namespace Core.Application.Common.Interfaces.Persistance
{
    public interface IMenuRepository
    {
        Task<ErrorOr<Created>> AddAsync(MenuEntity.Menu menu);
        Task<ErrorOr<Deleted>> DeleteByIdAsync(MenuId id);
        Task<ErrorOr<MenuEntity.Menu>> GetByIdAsync(MenuId id);
        Task<ErrorOr<List<MenuEntity.Menu>>> GetAllAsync();
        Task<ErrorOr<Updated>> UpdateAsync(MenuEntity.Menu menu);
    }
}