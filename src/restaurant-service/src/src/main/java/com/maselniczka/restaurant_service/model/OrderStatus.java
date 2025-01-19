package com.maselniczka.restaurant_service.model;

import lombok.Getter;
import lombok.RequiredArgsConstructor;

@RequiredArgsConstructor
@Getter
public enum OrderStatus {

    Cancelled(-1),
    Pending(0),
    Accepted(1),
    InPreparation(2),
    ReadyForCollection(3),
    InDelivery(4),
    Delivered(5);

    private final int value;

    private static final OrderStatus[] vals = values();

    public OrderStatus next() {
        return vals[(this.ordinal() + 1) % vals.length];
    }
}
