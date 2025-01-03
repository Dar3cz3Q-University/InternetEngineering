using Core.Contracts.Common.Request;

namespace Core.Contracts.Order.Request
{
    public record CreateOrderRequest(
        Guid UserId,
        Guid RestaurantId,
        Guid DeliveryAddress,
        List<Guid> ItemsIds);
}