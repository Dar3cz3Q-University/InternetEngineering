namespace Core.Contracts.Order.Request
{
    public record CreateOrderRequest(
        Guid RestaurantId,
        Guid DeliveryAddressId,
        List<ItemRequest> Items);

    public record ItemRequest(
        Guid ItemId,
        uint Quantity);
}