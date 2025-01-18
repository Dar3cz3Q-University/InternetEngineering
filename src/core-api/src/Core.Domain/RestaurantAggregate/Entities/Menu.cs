using Core.Domain.Common.Models;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.RestaurantAggregate.Entities
{
    public class Menu : Entity<MenuId>, IHasTimestamps
    {
        private readonly List<MenuSection> _sections = [];
        public virtual ICollection<MenuSection> Sections => _sections.AsReadOnly();
        public DateTime CreatedDateTime { get; set; } // TODO: Make setter private
        public DateTime UpdatedDateTime { get; set; } // TODO: Make setter private

        private Menu(
            MenuId id,
            List<MenuSection> sections) : base(id)
        {
            _sections = sections;
        }

        public static Menu Create()
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                []);

            return menu;
        }

#pragma warning disable CS8618
        protected Menu() { }
#pragma warning restore CS8618

        public void AddSection(MenuSection section)
        {
            _sections.Add(section);
        }

        public void AddItem(MenuSectionId sectionId, MenuItem item)
        {
            foreach (var section in Sections)
            {
                if (section.Id == sectionId)
                {
                    section.AddItem(item);
                }
            }

            // TODO: Throw error if section not found
        }

        public List<MenuItem> GetItems(List<MenuItemId> itemsIds)
        {
            var items = new List<MenuItem>();

            foreach (var section in Sections)
            {
                items.AddRange(section.Items.Where(i => itemsIds.Contains(i.Id)));
            }

            return items;
        }
    }
}