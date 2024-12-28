using Core.Domain.Common.Models;
using Core.Domain.MenuAggregate.Entities;
using Core.Domain.MenuAggregate.Events;
using Core.Domain.MenuAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = [];
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public RestaurantId RestaurantId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu(
            MenuId id,
            string name,
            string description,
            List<MenuSection> sections,
            RestaurantId restaurantId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            _sections = sections;
            RestaurantId = restaurantId;
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
                restaurantId,
                DateTime.UtcNow,
                DateTime.UtcNow);

            menu.AddDomainEvent(new MenuCreated(menu));

            return menu;
        }

#pragma warning disable CS8618
        private Menu() { }
#pragma warning restore CS8618
    }
}