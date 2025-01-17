namespace Core.Contracts.Order.Response
{
    public record OrderResponse(
        string Id,
        string RestaurantName,
        string OrderStatus,
        bool IsActive,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}