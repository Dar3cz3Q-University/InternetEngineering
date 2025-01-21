namespace Core.Contracts.Order.Request
{
    public record GetActiveOrderForCourier(
        double? Latitude,
        double? Longitude);
}
