using Core.Contracts.Common.Response;
using Core.Contracts.Order.DTO;

namespace Core.Contracts.Order.Response
{
    public record OrderResponse(
        string Id,
        string UserId,
        string RestaurantId,
        AddressResponse DeliveryAddress,
        MoneyResponse TotalPrice,
        OrderStatusDTO OrderStatus,
        Courier Courier,
        List<MenuItemResponse> Items);

    public record Courier(
        string Name);

    public record MenuItemResponse(
        string Id,
        string Name,
        string Description,
        MoneyResponse Price,
        bool IsAvailable,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}