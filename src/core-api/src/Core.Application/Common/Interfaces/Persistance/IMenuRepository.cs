using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.ValueObjects;

namespace Core.Application.Common.Interfaces.Persistance
{
    // TODO: [Create async repository functions #27]
    public interface IMenuRepository
    {
        Menu? GetById(MenuId id);
        List<Menu> All();
        Menu Add(Menu menu);
        Menu Update(Menu menu);
        void Delete(MenuId id);
    }
}