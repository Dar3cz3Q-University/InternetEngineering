namespace Core.Contracts.Order.Response
{
    public record OrderResponse(
        string Id,
        string RestaurantName,
        string ImageUrl,
        string OrderStatus,
        bool IsActive,
        DateTime UpdatedDateTime,
        DateTime CreatedDateTime);
}