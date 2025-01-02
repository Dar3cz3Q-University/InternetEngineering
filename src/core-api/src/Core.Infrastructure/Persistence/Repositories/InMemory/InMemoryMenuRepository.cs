using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.ValueObjects;

namespace Core.Infrastructure.Persistence.Repositories.InMemory
{
    public class InMemoryMenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menus = [];
        public Menu? GetById(MenuId id)
        {
            return _menus.Find(m => m.Id == id);
        }
        public List<Menu> All() => _menus;

        public Menu Add(Menu menu)
        {
            _menus.Add(menu);
            return menu;
        }
        public Menu Update(Menu menu)
        {
            throw new NotImplementedException();
        }
        public void Delete(MenuId id)
        {
            _menus.Remove(GetById(id));
        }
    }
}