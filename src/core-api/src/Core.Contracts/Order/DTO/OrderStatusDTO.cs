namespace Core.Contracts.Order.DTO
{
    public enum OrderStatusDTO
    {
        Cancelled = -1,
        Pending,
        Accepted,
        InPreparation,
        InDelivery,
        Delivered
    }
}
