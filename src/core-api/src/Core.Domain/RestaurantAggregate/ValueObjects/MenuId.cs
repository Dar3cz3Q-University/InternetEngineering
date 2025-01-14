using Core.Domain.Common.Models;

namespace Core.Domain.RestaurantAggregate.ValueObjects
{
    public class MenuId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUnique() => new(Guid.NewGuid());

        public static MenuId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        protected MenuId() { }
#pragma warning restore CS8618
    }
}