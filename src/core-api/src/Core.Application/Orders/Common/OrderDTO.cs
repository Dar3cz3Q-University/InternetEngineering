using Core.Domain.Common.Entities;
using Core.Domain.Common.ValueObjects;
using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Application.Orders.Common
{
    public record OrderDTO(
        OrderId OrderId,
        UserId UserId,
        RestaurantId RestaurantId,
        Address DeliveryAddress,
        OrderStatus OrderStatus,
        Money TotalPrice,
        UserId? CourierId,
        List<MenuItem> Items,
        DateTime? DeliveryTime,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);
}