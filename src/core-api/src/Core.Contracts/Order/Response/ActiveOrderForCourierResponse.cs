using Core.Contracts.Common.Response;

namespace Core.Contracts.Order.Response
{
    public record ActiveOrderForCourierResponse(
        string Id,
        string RestaurantName,
        string ImageUrl,
        double? Distance,
        AddressResponse RestaurantAddress,
        AddressResponse DeliveryAddress,
        MoneyResponse TotalPrice,
        DateTime EstimatedDeliveryTime,
        DateTime UpdatedDateTime,
        DateTime CreatedDateTime);
}