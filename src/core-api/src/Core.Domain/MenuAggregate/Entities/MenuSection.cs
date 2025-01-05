using Core.Domain.Common.Models;
using Core.Domain.MenuAggregate.ValueObjects;

namespace Core.Domain.MenuAggregate.Entities
{
    public class MenuSection : Entity<MenuSectionId>, IHasTimestamps
    {
        private readonly List<MenuItem> _items = [];
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<MenuItem> Items => _items.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private MenuSection(
            MenuSectionId id,
            string name,
            string description,
            List<MenuItem> items,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            _items = items;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static MenuSection Create(
            string name,
            string description,
            List<MenuItem> items)
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description,
                items,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        protected MenuSection() { }
#pragma warning restore CS8618
    }
}