using Core.Domain.Common.Models;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.RestaurantAggregate.Entities
{
    public class Menu : Entity<MenuId>, IHasTimestamps
    {
        private readonly List<MenuSection> _sections = [];
        public virtual ICollection<MenuSection> Sections => _sections.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu(
            MenuId id,
            List<MenuSection> sections,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            _sections = sections;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create()
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                [],
                DateTime.UtcNow,
                DateTime.UtcNow);

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
    }
}