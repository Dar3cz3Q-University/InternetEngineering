using Core.Domain.Common.Models;
using Core.Domain.Common.ValueObjects;
using Core.Domain.OrderAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Domain.OrderAggregate
{
    public class Order : AggregateRoot<OrderId>, IHasTimestamps
    {
        private readonly List<MenuItemId> _itemsIds = [];
        public virtual UserId UserId { get; private set; }
        public virtual RestaurantId RestaurantId { get; private set; }
        public virtual AddressId DeliveryAddressId { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public Money TotalPrice { get; private set; }
        public virtual UserId? CourierId { get; private set; }
        public virtual ICollection<MenuItemId> ItemsIds => _itemsIds.AsReadOnly();
        public DateTime? DeliveryTime { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Order(
            OrderId id,
            UserId userId,
            RestaurantId restaurantId,
            AddressId deliveryAddressId,
            OrderStatus orderStatus,
            Money totalPrice,
            List<MenuItemId> items,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            Id = id;
            UserId = userId;
            RestaurantId = restaurantId;
            DeliveryAddressId = deliveryAddressId;
            OrderStatus = orderStatus;
            TotalPrice = totalPrice;
            _itemsIds = items;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Order Create(
            UserId userId,
            RestaurantId restaurantId,
            AddressId deliveryAddressId,
            List<MenuItemId> items)
        {
            var temp = Money.Create(
                15.26m,
                "PLN");

            return new(
                OrderId.CreateUnique(),
                userId,
                restaurantId,
                deliveryAddressId,
                OrderStatus.Pending,
                temp, // TODO: Calculate total price
                items,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        protected Order() { }
#pragma warning restore CS8618
    }
}