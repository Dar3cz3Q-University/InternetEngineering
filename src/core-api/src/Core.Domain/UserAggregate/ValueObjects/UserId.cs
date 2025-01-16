using Core.Domain.Common.Models;

namespace Core.Domain.UserAggregate.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get; private set; }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId CreateUnique() => new(Guid.NewGuid());

        public static UserId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

#pragma warning disable CS8618
        protected UserId() { }
#pragma warning restore CS8618
    }
}