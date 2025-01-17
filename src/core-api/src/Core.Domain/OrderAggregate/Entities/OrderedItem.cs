using Core.Domain.Common.Models;
using Core.Domain.OrderAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;

namespace Core.Domain.OrderAggregate.Entities
{
    public class OrderedItem : Entity<OrderedItemId>
    {
        public MenuItemId ItemId { get; private set; }
        public uint Quantity { get; private set; }

        private OrderedItem(
            OrderedItemId id,
            MenuItemId itemId,
            uint quantity) : base(id)
        {
            ItemId = itemId;
            Quantity = quantity;
        }

        public static OrderedItem Create(
            MenuItemId itemId,
            uint quantity)
        {
            return new(
                OrderedItemId.CreateUnique(),
                itemId,
                quantity);
        }

#pragma warning disable CS8618
        protected OrderedItem() { }
#pragma warning restore CS8618
    }
}