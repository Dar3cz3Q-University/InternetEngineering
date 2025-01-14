using Core.Domain.Common.Models;

namespace Core.Domain.RestaurantAggregate.ValueObjects
{
    public class MenuSectionId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

        public static MenuSectionId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

#pragma warning disable CS8618
        protected MenuSectionId() { }
#pragma warning restore CS8618
    }
}