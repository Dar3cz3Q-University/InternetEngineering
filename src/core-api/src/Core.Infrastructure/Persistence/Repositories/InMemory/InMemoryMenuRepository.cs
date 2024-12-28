using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.ValueObjects;

namespace Core.Infrastructure.Persistence.Repositories.InMemory
{
    public class InMemoryMenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menus = [];
        public Menu? Get(MenuId id)
        {
            return _menus.Find(r => r.Id == id);
        }
        public List<Menu> GetAll()
        {
            return _menus;
        }

        public void Add(Menu restaurant)
        {
            _menus.Add(restaurant);
        }

        public void Delete(MenuId id)
        {
            _menus.Remove(Get(id));
        }
    }
}
