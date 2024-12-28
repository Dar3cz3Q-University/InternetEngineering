using Core.Domain.RestaurantAggregate.ValueObjects;
using ErrorOr;

namespace Core.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Restaurant
        {
            public static Error NotFound(RestaurantId id) => Error.NotFound(
                code: "Restaurant.NotFound",
                description: "Restaurant with ID: '" + id.Value.ToString() + "' doesn't exists.");
        }
    }
}
