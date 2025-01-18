using Core.Domain.Common.Models;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.RestaurantAggregate.Entities
{
    public class MenuSection : Entity<MenuSectionId>, IHasTimestamps
    {
        private readonly List<MenuItem> _items = [];
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<MenuItem> Items => _items.AsReadOnly();
        public DateTime CreatedDateTime { get; set; } // TODO: Make setter private
        public DateTime UpdatedDateTime { get; set; } // TODO: Make setter private

        private MenuSection(
            MenuSectionId id,
            string name,
            string description,
            List<MenuItem> items) : base(id)
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public static MenuSection Create(
            string name,
            string description)
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description,
                []);
        }

#pragma warning disable CS8618
        protected MenuSection() { }
#pragma warning restore CS8618

        public void AddItem(MenuItem item)
        {
            _items.Add(item);
        }
    }
}