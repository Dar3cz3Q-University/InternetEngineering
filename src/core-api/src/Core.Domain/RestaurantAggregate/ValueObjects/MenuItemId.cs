using Core.Domain.Common.Models;

namespace Core.Domain.RestaurantAggregate.ValueObjects
{
    public class MenuItemId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId CreateUnique() => new(Guid.NewGuid());

        public static MenuItemId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        protected MenuItemId() { }
#pragma warning restore CS8618
    }
}