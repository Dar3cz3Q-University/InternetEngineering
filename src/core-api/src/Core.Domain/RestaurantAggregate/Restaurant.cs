using Core.Domain.Common.Entities;
using Core.Domain.Common.Models;
using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.RestaurantAggregate
{
    public class Restaurant : AggregateRoot<RestaurantId>, IHasTimestamps
    {
        public string ImageUrl { get; private set; }
        public string Name { get; private set; }
        public virtual Address Location { get; private set; }
        public string Description { get; private set; }
        public ContactInfo ContactInfo { get; private set; }
        public OpeningHours OpeningHours { get; private set; }
        public bool IsOpen { get; private set; }
        public virtual Menu Menu { get; private set; }
        public double AverageRate { get; private set; }
        public uint RatesCount { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Restaurant(
            RestaurantId id,
            string name,
            string imageUrl,
            Address location,
            string description,
            ContactInfo contactInfo,
            OpeningHours openingHours,
            bool isOpen,
            Menu menu,
            double averageRate,
            uint ratesCount,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            ImageUrl = imageUrl;
            Location = location;
            Description = description;
            ContactInfo = contactInfo;
            OpeningHours = openingHours;
            IsOpen = isOpen;
            Menu = menu;
            AverageRate = averageRate;
            RatesCount = ratesCount;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Restaurant Create(
            string name,
            string imageUrl,
            Address location,
            string description,
            ContactInfo contactInfo,
            OpeningHours openingHours)
        {
            return new(
                RestaurantId.CreateUnique(),
                name,
                imageUrl,
                location,
                description,
                contactInfo,
                openingHours,
                false,
                Menu.Create(),
                0.0,
                0,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        protected Restaurant() { }
#pragma warning restore CS8618

        public void AddMenuSection(MenuSection menuSection)
        {
            Menu.AddSection(menuSection);
        }

        public void AddMenuItem(MenuSectionId sectionId, MenuItem item)
        {
            Menu.AddItem(sectionId, item);
        }

        public void AddRate(double rate)
        {
            AverageRate = (AverageRate + rate) / (RatesCount == 0 ? 1 : 2);
            RatesCount++;
        }
    }
}