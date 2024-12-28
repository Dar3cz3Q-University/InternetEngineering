using Core.Domain.Common.Models;

namespace Core.Domain.OrderAggregate.ValueObjects
{
    public sealed class OrderId : ValueObject
    {
        public Guid Value { get; private set; }

        private OrderId(Guid value)
        {
            Value = value;
        }

        public static OrderId CreateUnique() => new(Guid.NewGuid());

        public static OrderId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
