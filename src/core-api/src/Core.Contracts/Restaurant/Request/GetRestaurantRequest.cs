namespace Core.Contracts.Restaurant.Request
{
    public record GetRestaurantRequest(
        double? Latitude,
        double? Longitude);
}