using Core.Domain.Common.Models;

namespace Core.Domain.RestaurantAggregate.ValueObjects
{
    public class RestaurantId : ValueObject
    {
        public Guid Value { get; private set; }

        private RestaurantId(Guid value)
        {
            Value = value;
        }

        public static RestaurantId CreateUnique() => new(Guid.NewGuid());

        public static RestaurantId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        protected RestaurantId() { }
    }
}