using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;
using ErrorOr;

namespace Core.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Favorite
        {
            public static Error AlreadyExists(UserId userId, RestaurantId restaurantId) => Error.Conflict(
                code: "Favorite.AlreadyExists",
                description: $"Restaurant '{restaurantId.Value}' is already in favorites for user '{userId.Value}'.");

            public static Error NotFound(UserId userId, RestaurantId restaurantId) => Error.NotFound(
                code: "Favorite.NotFound",
                description: $"Restaurant '{restaurantId.Value}' is not in favorites for user '{userId.Value}'.");
        }
    }
}
