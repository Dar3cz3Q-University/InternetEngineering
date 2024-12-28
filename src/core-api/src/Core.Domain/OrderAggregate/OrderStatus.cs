namespace Core.Domain.OrderAggregate
{
    public enum OrderStatus
    {
        Cancelled = -1,
        Pending,
        Accepted,
        InPreparation,
        InDelivery,
        Delivered
    }
}
