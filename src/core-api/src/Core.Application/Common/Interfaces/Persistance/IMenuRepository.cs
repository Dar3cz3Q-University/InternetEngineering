using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.ValueObjects;
using ErrorOr;

namespace Core.Application.Common.Interfaces.Persistance
{
    public interface IMenuRepository
    {
        Task<ErrorOr<Created>> AddAsync(Menu menu);
        Task<ErrorOr<Deleted>> DeleteByIdAsync(MenuId id);
        Task<ErrorOr<Menu>> GetByIdAsync(MenuId id);
        Task<ErrorOr<List<Menu>>> GetAllAsync();
        Task<ErrorOr<Updated>> UpdateAsync(Menu menu);
    }
}