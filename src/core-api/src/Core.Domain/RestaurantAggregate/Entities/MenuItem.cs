using Core.Domain.Common.Models;
using Core.Domain.Common.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.RestaurantAggregate.Entities
{
    public class MenuItem : Entity<MenuItemId>, IHasTimestamps
    {
        public string Name { get; private set; }
        public string ImageUrl { get; private set; }
        public string Description { get; private set; }
        public Money Price { get; private set; }
        public bool IsAvailable { get; private set; }
        public DateTime CreatedDateTime { get; set; } // TODO: Make setter private
        public DateTime UpdatedDateTime { get; set; } // TODO: Make setter private

        private MenuItem(
            MenuItemId id,
            string name,
            string imageUrl,
            string description,
            Money price,
            bool isAvailable) : base(id)
        {
            Name = name;
            ImageUrl = imageUrl;
            Description = description;
            Price = price;
            IsAvailable = isAvailable;
        }

        public static MenuItem Create(
            string name,
            string imageUrl,
            string description,
            Money price)
        {
            return new(
                MenuItemId.CreateUnique(),
                name,
                imageUrl,
                description,
                price,
                true);
        }

#pragma warning disable CS8618
        protected MenuItem() { }
#pragma warning restore CS8618
    }
}