using Core.Domain.Common.Entities;
using Core.Domain.Common.Models;
using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.RestaurantAggregate
{
    public class Restaurant : AggregateRoot<RestaurantId>, IHasTimestamps
    {
        public string Name { get; private set; }
        public virtual Address Location { get; private set; }
        public string Description { get; private set; }
        public ContactInfo ContactInfo { get; private set; }
        public OpeningHours OpeningHours { get; private set; }
        public bool IsOpen { get; private set; }
        public virtual Menu Menu { get; private set; }
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
            Menu menu,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Location = location;
            Description = description;
            ContactInfo = contactInfo;
            OpeningHours = openingHours;
            IsOpen = isOpen;
            Menu = menu;
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
            return new(
                RestaurantId.CreateUnique(),
                name,
                location,
                description,
                contactInfo,
                openingHours,
                false,
                Menu.Create(),
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
    }
}