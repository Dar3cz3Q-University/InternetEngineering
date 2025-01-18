namespace Core.Contracts.Restaurant.Request
{
    public record GetRestaurantsRequest(
        double? Latitude,
        double? Longitude,
        List<Guid>? Categories);
}