using Core.Domain.Common.Models;

namespace Core.Domain.UserAggregate.ValueObjects
{
    public class FavoriteRestaurantId : ValueObject
    {
        public Guid Value { get; private set; }

        private FavoriteRestaurantId(Guid value)
        {
            Value = value;
        }

        public static FavoriteRestaurantId CreateUnique() => new(Guid.NewGuid());

        public static FavoriteRestaurantId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

#pragma warning disable CS8618
        protected FavoriteRestaurantId() { }
#pragma warning restore CS8618
    }
}
