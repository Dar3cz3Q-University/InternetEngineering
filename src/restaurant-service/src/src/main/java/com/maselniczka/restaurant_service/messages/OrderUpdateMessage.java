package com.maselniczka.restaurant_service.messages;

import java.time.ZonedDateTime;

public record OrderUpdateMessage(

        String OrderId,
        int OrderStatus,
        ZonedDateTime DeliveryDateTime
) {}
