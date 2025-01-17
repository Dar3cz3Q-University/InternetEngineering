using Core.Domain.Common.Models;

namespace Core.Domain.OrderAggregate.ValueObjects
{
    public class OrderedItemId : ValueObject
    {
        public Guid Value { get; private set; }

        private OrderedItemId(Guid value)
        {
            Value = value;
        }

        public static OrderedItemId CreateUnique() => new(Guid.NewGuid());

        public static OrderedItemId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        protected OrderedItemId() { }
#pragma warning restore CS8618
    }
}