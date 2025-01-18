using Core.Domain.CategoryAggregate.ValueObjects;
using Core.Domain.Common.Models;

namespace Core.Domain.CategoryAggregate
{
    public class Category : Entity<CategoryId>, IHasTimestamps
    {
        public string Name { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime CreatedDateTime { get; set; } // TODO: Make setter private
        public DateTime UpdatedDateTime { get; set; } // TODO: Make setter private

        private Category(
            CategoryId id,
            string name,
            string imageUrl) : base(id)
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public static Category Create(
            string name,
            string imageUrl)
        {
            return new(
                CategoryId.CreateUnique(),
                name,
                imageUrl);
        }

#pragma warning disable CS8618
        protected Category() { }
#pragma warning restore CS8618
    }
}
