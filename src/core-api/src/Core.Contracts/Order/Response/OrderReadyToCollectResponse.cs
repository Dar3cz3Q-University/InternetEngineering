using Core.Contracts.Common.Response;

namespace Core.Contracts.Order.Response
{
    public record OrderReadyToCollectResponse(
        string Id,
        string RestaurantName,
        string ImageUrl,
        double? Distance,
        AddressResponse RestaurantAddress,
        AddressResponse DeliveryAddress,
        DateTime UpdatedDateTime,
        DateTime CreatedDateTime);
}
