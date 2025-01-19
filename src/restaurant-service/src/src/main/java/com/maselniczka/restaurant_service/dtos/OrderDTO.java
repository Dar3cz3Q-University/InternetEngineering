package com.maselniczka.restaurant_service.dtos;

import java.util.List;

public record OrderDTO (
        String OrderId,
        double Distance,
        List<OrderItemDTO> Items
){}
