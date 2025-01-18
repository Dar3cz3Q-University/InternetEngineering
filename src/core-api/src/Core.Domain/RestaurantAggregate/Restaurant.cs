using Core.Domain.CategoryAggregate.ValueObjects;
using Core.Domain.Common.Entities;
using Core.Domain.Common.Models;
using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.RestaurantAggregate
{
    public class Restaurant : AggregateRoot<RestaurantId>, IHasTimestamps
    {
        private readonly List<CategoryId> _categories = [];
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
        public virtual ICollection<CategoryId> Categories => _categories;
        public DateTime CreatedDateTime { get; set; } // TODO: Make setter private
        public DateTime UpdatedDateTime { get; set; } // TODO: Make setter private

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
            List<CategoryId> categories) : base(id)
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
            _categories = categories;
        }

        public static Restaurant Create(
            string name,
            string imageUrl,
            Address location,
            string description,
            List<CategoryId> categories,
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
                categories);
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

        public List<MenuItem> GetItems(List<MenuItemId> itemIds)
        {
            return Menu.GetItems(itemIds);
        }
    }
}