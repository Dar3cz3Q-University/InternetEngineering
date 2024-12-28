using Core.Domain.Common.Models;
using Core.Domain.Common.ValueObjects;
using Core.Domain.MenuAggregate.Entities;
using Core.Domain.OrderAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Domain.OrderAggregate
{
    public sealed class Order : AggregateRoot<OrderId>
    {
        private readonly List<MenuItem> _items = [];
        public UserId UserId { get; private set; }
        public RestaurantId RestaurantId { get; private set; }
        public Address DeliveryAddress { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public Money TotalPrice { get; private set; }
        public UserId? CourierId { get; private set; }
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
        public DateTime? DeliveryTime { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTIme { get; private set; }

        private Order(
            UserId userId,
            RestaurantId restaurantId,
            Address deliveryAddress,
            OrderStatus orderStatus,
            Money totalPrice,
            List<MenuItem> items,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            UserId = userId;
            RestaurantId = restaurantId;
            DeliveryAddress = deliveryAddress;
            OrderStatus = orderStatus;
            TotalPrice = totalPrice;
            _items = items;
            CreatedDateTime = createdDateTime;
            UpdatedDateTIme = updatedDateTime;
        }

        public static Order Create(
            UserId userId,
            RestaurantId restaurantId,
            Address deliveryAddress,
            Money totalPrice,
            List<MenuItem> items)
        {
            return new(
                userId,
                restaurantId,
                deliveryAddress,
                OrderStatus.Pending,
                totalPrice,
                items,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        private Order() { }
#pragma warning restore CS8618
    }
}
