﻿using Core.Domain.Common.Models;
using Core.Domain.Common.ValueObjects;
using Core.Domain.OrderAggregate.Entities;
using Core.Domain.OrderAggregate.Events;
using Core.Domain.OrderAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;

namespace Core.Domain.OrderAggregate
{
    public class Order : AggregateRoot<OrderId>, IHasTimestamps
    {
        private readonly List<OrderedItem> _orderedItems = [];
        public virtual UserId UserId { get; private set; }
        public virtual RestaurantId RestaurantId { get; private set; }
        public virtual AddressId DeliveryAddressId { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public Money TotalPrice { get; private set; }
        public virtual UserId? CourierId { get; private set; }
        public virtual ICollection<OrderedItem> OrderedItems => _orderedItems.AsReadOnly();
        public DateTime? DeliveryTime { get; private set; }
        public DateTime CreatedDateTime { get; set; } // TODO: Make setter private
        public DateTime UpdatedDateTime { get; set; } // TODO: Make setter private

        private Order(
            OrderId id,
            UserId userId,
            RestaurantId restaurantId,
            AddressId deliveryAddressId,
            OrderStatus orderStatus,
            Money totalPrice,
            List<OrderedItem> items,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            Id = id;
            UserId = userId;
            RestaurantId = restaurantId;
            DeliveryAddressId = deliveryAddressId;
            OrderStatus = orderStatus;
            TotalPrice = totalPrice;
            _orderedItems = items;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Order Create(
            UserId userId,
            RestaurantId restaurantId,
            AddressId deliveryAddressId,
            Money totalPrice,
            List<OrderedItem> items)
        {
            var order = new Order(
                OrderId.CreateUnique(),
                userId,
                restaurantId,
                deliveryAddressId,
                OrderStatus.Pending,
                totalPrice,
                items,
                DateTime.UtcNow,
                DateTime.UtcNow);

            order.AddDomainEvent(new OrderCreated(order));

            return order;
        }

#pragma warning disable CS8618
        protected Order() { }
#pragma warning restore CS8618

        public void SetOrderStatus(OrderStatus orderStatus)
        {
            OrderStatus = orderStatus;
        }

        public void SetDeliveryDateTime(DateTime? deliveryDateTime)
        {
            DeliveryTime = deliveryDateTime;
        }

        public void SetCourierId(UserId courierId)
        {
            CourierId = courierId;
        }
    }
}