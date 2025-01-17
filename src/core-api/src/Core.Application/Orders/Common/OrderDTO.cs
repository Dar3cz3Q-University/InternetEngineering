using Core.Domain.OrderAggregate;
using Core.Domain.RestaurantAggregate;

namespace Core.Application.Orders.Common
{
    public record OrderDTO(
        Order Order,
        Restaurant Restaurant);
}