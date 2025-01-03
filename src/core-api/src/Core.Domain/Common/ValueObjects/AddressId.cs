using Core.Domain.Common.Models;

namespace Core.Domain.Common.ValueObjects
{
    public sealed class AddressId : ValueObject
    {
        public Guid Value { get; private set; }

        private AddressId(Guid value)
        {
            Value = value;
        }

        public static AddressId CreateUnique() => new(Guid.NewGuid());

        public static AddressId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}