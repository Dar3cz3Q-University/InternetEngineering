using Core.Contracts.Common.Response;
using Core.Contracts.Restaurant.Response;

namespace Core.Contracts.Order.Response
{
    public record OrderResponseWithDetails(
        string Id,
        string OrderStatus,
        RestaurantResponse Restaurant,
        AddressResponse DeliveryAddress,
        List<ItemReponse> Items,
        MoneyResponse TotalPrice,
        string CourierName,
        DateTime? EstimatedDeliveryDateTime,
        bool IsActive,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record ItemReponse(
        string Id,
        string Name,
        string ImageUrl,
        MoneyResponse Price,
        uint Quantity);
}