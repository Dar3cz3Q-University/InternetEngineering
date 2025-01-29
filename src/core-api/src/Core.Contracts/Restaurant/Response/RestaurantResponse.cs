namespace Core.Contracts.Restaurant.Response
{
    public record RestaurantResponse(
        string Id,
        string Name,
        string Description,
        string ImageUrl,
        double? Distance,
        double AverageRate,
        double RatesCount,
        bool IsActive);
}