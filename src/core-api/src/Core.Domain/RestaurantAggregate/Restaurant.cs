using Core.Domain.Common.Models;
using Core.Domain.Common.ValueObjects;
using Core.Domain.MenuAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.RestaurantAggregate
{
    public sealed class Restaurant : Entity<RestaurantId>, IHasTimestamps
    {
        public string Name { get; private set; }
        public Address Location { get; private set; }
        public string Description { get; private set; }
        public ContactInfo ContactInfo { get; private set; }
        public OpeningHours OpeningHours { get; private set; }
        public bool IsOpen { get; private set; }
        public MenuId? MenuId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Restaurant(
            RestaurantId id,
            string name,
            Address location,
            string description,
            ContactInfo contactInfo,
            OpeningHours openingHours,
            bool isOpen,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Location = location;
            Description = description;
            ContactInfo = contactInfo;
            OpeningHours = openingHours;
            IsOpen = isOpen;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Restaurant Create(
            string name,
            Address location,
            string description,
            ContactInfo contactInfo,
            OpeningHours openingHours)
        {
            var restaurant = new Restaurant(
                RestaurantId.CreateUnique(),
                name,
                location,
                description,
                contactInfo,
                openingHours,
                false,
                DateTime.UtcNow,
                DateTime.UtcNow);

            return restaurant;
        }

#pragma warning disable CS8618
        private Restaurant() { }
#pragma warning restore CS8618
    }
}