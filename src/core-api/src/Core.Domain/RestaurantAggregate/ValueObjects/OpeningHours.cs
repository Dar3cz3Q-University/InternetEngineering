using Core.Domain.Common.Models;

namespace Core.Domain.RestaurantAggregate.ValueObjects
{
    public class OpeningHours : ValueObject
    {
        public TimeOnly OpenTime { get; }
        public TimeOnly CloseTime { get; }

        private OpeningHours(
            TimeOnly openTime,
            TimeOnly closeTime)
        {
            OpenTime = openTime;
            CloseTime = closeTime;
        }

        public static OpeningHours Create(
            TimeOnly openTime,
            TimeOnly closeTime)
        {
            return new(openTime, closeTime);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return OpenTime;
            yield return CloseTime;
        }

#pragma warning disable CS8618
        protected OpeningHours() { }
#pragma warning restore CS8618
    }
}