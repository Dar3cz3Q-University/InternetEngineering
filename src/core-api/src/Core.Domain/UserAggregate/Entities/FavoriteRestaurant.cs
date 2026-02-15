using Core.Domain.Common.Models;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Domain.UserAggregate.Entities
{
    public class FavoriteRestaurant : Entity<FavoriteRestaurantId>, IHasTimestamps
    {
        public UserId UserId { get; private set; }
        public RestaurantId RestaurantId { get; private set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private FavoriteRestaurant(
            FavoriteRestaurantId id,
            UserId userId,
            RestaurantId restaurantId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(id)
        {
            UserId = userId;
            RestaurantId = restaurantId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static FavoriteRestaurant Create(UserId userId, RestaurantId restaurantId)
        {
            return new(
                FavoriteRestaurantId.CreateUnique(),
                userId,
                restaurantId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        protected FavoriteRestaurant() { }
#pragma warning restore CS8618
    }
}
