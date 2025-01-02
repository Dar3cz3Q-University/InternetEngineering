﻿using Core.Contracts.Common.Request;

namespace Core.Contracts.Order.Request
{
    public record CreateOrderRequest(
        Guid UserId,
        Guid RestaurantId,
        AddressRequest DeliveryAddress,
        List<Guid> ItemsIds);
}