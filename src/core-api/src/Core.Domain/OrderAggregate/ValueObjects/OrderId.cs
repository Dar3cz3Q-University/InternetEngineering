using Core.Domain.Common.Models;

namespace Core.Domain.OrderAggregate.ValueObjects
{
    public class OrderId : ValueObject
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

#pragma warning disable CS8618
        protected OrderId() { }
#pragma warning restore CS8618
    }
}