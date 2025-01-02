using Core.Domain.Common.Models;
using Core.Domain.Common.ValueObjects;
using Core.Domain.MenuAggregate.ValueObjects;
using Core.Domain.OrderAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Domain.OrderAggregate
{
    public sealed class Order : AggregateRoot<OrderId>, IHasTimestamps
    {
        private readonly List<MenuItemId> _items = [];
        public UserId UserId { get; private set; }
        public RestaurantId RestaurantId { get; private set; }
        public Address DeliveryAddress { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public Money TotalPrice { get; private set; }
        public UserId? CourierId { get; private set; }
        public IReadOnlyList<MenuItemId> Items => _items.AsReadOnly();
        public DateTime? DeliveryTime { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Order(
            OrderId id,
            UserId userId,
            RestaurantId restaurantId,
            Address deliveryAddress,
            OrderStatus orderStatus,
            Money totalPrice,
            List<MenuItemId> items,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            Id = id;
            UserId = userId;
            RestaurantId = restaurantId;
            DeliveryAddress = deliveryAddress;
            OrderStatus = orderStatus;
            TotalPrice = totalPrice;
            _items = items;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Order Create(
            UserId userId,
            RestaurantId restaurantId,
            Address deliveryAddress,
            List<MenuItemId> items)
        {
            var temp = Money.Create(
                15.26m,
                "PLN");

            return new(
                OrderId.CreateUnique(),
                userId,
                restaurantId,
                deliveryAddress,
                OrderStatus.Pending,
                temp, // TODO: Calculate total price
                items,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        private Order() { }
#pragma warning restore CS8618
    }
}