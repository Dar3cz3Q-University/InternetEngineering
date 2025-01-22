namespace Core.Contracts.Order.Request
{
    public record GetOrdersReadyToCollectRequest(
        double? Latitude,
        double? Longitude);
}