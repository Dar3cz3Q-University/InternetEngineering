using Core.Domain.OrderAggregate;

namespace Core.Application.Common.Dtos
{
    public record OrderUpdateMessageDTO(
        Guid OrderId,
        OrderStatus OrderStatus,
        DateTime? DeliveryDateTime);
}
