using Core.Application.Restaurants.Common;
using Core.Domain.Common.Entities;
using Core.Domain.OrderAggregate;

namespace Core.Application.Orders.Common
{
    public record OrderWithAddressesDTO(
        Order Order,
        RestaurantDTO Restaurant,
        Address DeliveryAddress);
}