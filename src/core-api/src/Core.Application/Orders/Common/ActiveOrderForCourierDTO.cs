using Core.Domain.Common.Entities;
using Core.Domain.OrderAggregate;
using Core.Domain.RestaurantAggregate;

namespace Core.Application.Orders.Common
{
    public record ActiveOrderForCourierDTO(
        Order Order,
        Restaurant Restaurant,
        double? Distance,
        Address DeliveryAddress);
}
