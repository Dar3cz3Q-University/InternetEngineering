using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Persistance
{
    public interface IMenuRepository
    {
        Menu? Get(MenuId id);
        List<Menu> GetAll();
        void Add(Menu restaurant);
        void Delete(MenuId id);
    }
}