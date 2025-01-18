namespace Core.Application.Common.Dtos
{
    public record OrderCreatedMessageDTO(
        Guid OrderId,
        double Distance,
        List<OrderedItemDTO> Items);

    public record OrderedItemDTO(
        Guid ItemId,
        double Quantity);
}