using Core.Application.Restaurants.Common;
using Core.Domain.Common.Entities;
using Core.Domain.OrderAggregate;
using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.UserAggregate;

namespace Core.Application.Orders.Common
{
    public record OrderWithDetailsDTO(
        Order Order,
        RestaurantDTO Restaurant,
        Address DeliveryAddress,
        List<OrderedItemDTO> Items,
        User? Courier);

    public record OrderedItemDTO(
        MenuItem MenuItem,
        uint Quantity);
}