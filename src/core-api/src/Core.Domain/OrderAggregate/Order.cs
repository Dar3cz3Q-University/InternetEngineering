﻿using Core.Domain.Common.Models;
using Core.Domain.Common.ValueObjects;
using Core.Domain.OrderAggregate.Entities;
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
            List<OrderedItem> items)
        {
            Id = id;
            UserId = userId;
            RestaurantId = restaurantId;
            DeliveryAddressId = deliveryAddressId;
            OrderStatus = orderStatus;
            TotalPrice = totalPrice;
            _orderedItems = items;
        }

        public static Order Create(
            UserId userId,
            RestaurantId restaurantId,
            AddressId deliveryAddressId,
            Money totalPrice,
            List<OrderedItem> items)
        {
            return new(
                OrderId.CreateUnique(),
                userId,
                restaurantId,
                deliveryAddressId,
                OrderStatus.Pending,
                totalPrice,
                items);
        }

#pragma warning disable CS8618
        protected Order() { }
#pragma warning restore CS8618
    }
}