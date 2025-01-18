using Core.Domain.Common.Models;

namespace Core.Domain.CategoryAggregate.ValueObjects
{
    public class CategoryId : ValueObject
    {
        public Guid Value { get; private set; }

        private CategoryId(Guid value)
        {
            Value = value;
        }

        public static CategoryId CreateUnique() => new(Guid.NewGuid());

        public static CategoryId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is CategoryId other && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

#pragma warning disable CS8618
        protected CategoryId() { }
#pragma warning restore CS8618
    }
}