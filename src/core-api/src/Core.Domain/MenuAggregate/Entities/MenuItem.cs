using Core.Domain.Common.Models;
using Core.Domain.Common.ValueObjects;
using Core.Domain.MenuAggregate.ValueObjects;

namespace Core.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>, IHasTimestamps
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Money Price { get; private set; }
        public bool IsAvailable { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private MenuItem(
            MenuItemId id,
            string name,
            string description,
            Money price,
            bool isAvailable,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            IsAvailable = isAvailable;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static MenuItem Create(
            string name,
            string description,
            Money price)
        {
            return new(
                MenuItemId.CreateUnique(),
                name,
                description,
                price,
                true,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        private MenuItem() { }
#pragma warning restore CS8618
    }
}