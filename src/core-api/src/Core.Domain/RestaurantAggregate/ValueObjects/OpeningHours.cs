using Core.Domain.Common.Models;

namespace Core.Domain.RestaurantAggregate.ValueObjects
{
    public sealed class OpeningHours : ValueObject
    {
        public DateTime OpenTime { get; }
        public DateTime CloseTime { get; }

        private OpeningHours(
            DateTime openTime,
            DateTime closeTime)
        {
            OpenTime = openTime;
            CloseTime = closeTime;
        }

        public static OpeningHours Create(
            DateTime openTime,
            DateTime closeTime)
        {
            return new(openTime, closeTime);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return OpenTime;
            yield return CloseTime;
        }
    }
}