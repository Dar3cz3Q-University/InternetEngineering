using Core.Domain.Common.Models;
using Core.Domain.MenuAggregate.Entities;
using Core.Domain.MenuAggregate.Events;
using Core.Domain.MenuAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.MenuAggregate
{
    public class Menu : AggregateRoot<MenuId>, IHasTimestamps
    {
        private readonly List<MenuSection> _sections = [];
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<MenuSection> Sections => _sections.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu(
            MenuId id,
            string name,
            string description,
            List<MenuSection> sections,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            _sections = sections;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            string name,
            string description,
            List<MenuSection> sections,
            RestaurantId restaurantId)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                name,
                description,
                sections,
                DateTime.UtcNow,
                DateTime.UtcNow);

            menu.AddDomainEvent(new MenuCreated(menu.Id, restaurantId));

            return menu;
        }

#pragma warning disable CS8618
        protected Menu() { }
#pragma warning restore CS8618
    }
}