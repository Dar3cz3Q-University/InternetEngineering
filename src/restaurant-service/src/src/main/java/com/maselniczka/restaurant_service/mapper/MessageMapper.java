package com.maselniczka.restaurant_service.mapper;

import com.maselniczka.restaurant_service.messages.OrderUpdateMessage;
import com.maselniczka.restaurant_service.model.Order;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Component;

import java.time.ZonedDateTime;
import java.time.ZoneId;

@Component
@RequiredArgsConstructor
public class MessageMapper {

    public OrderUpdateMessage mapToMessage(Order order) {

        ZonedDateTime estimatedDelivery = null;

        if (order.getEstimatedDeliveryTime() != null) {
            estimatedDelivery = order.getEstimatedDeliveryTime().atZone(ZoneId.of("UTC"));
        }

        return new OrderUpdateMessage(
                order.getOrderId(),
                order.getStatus().getValue(),
                estimatedDelivery
        );
    }
}
