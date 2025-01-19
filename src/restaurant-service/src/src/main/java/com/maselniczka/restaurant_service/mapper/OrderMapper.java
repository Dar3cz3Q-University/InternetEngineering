package com.maselniczka.restaurant_service.mapper;

import com.maselniczka.restaurant_service.dtos.OrderDTO;
import com.maselniczka.restaurant_service.model.Order;
import com.maselniczka.restaurant_service.model.OrderItem;
import com.maselniczka.restaurant_service.model.OrderStatus;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Component;

import java.time.LocalDateTime;

@Component
@RequiredArgsConstructor
public class OrderMapper {

    public Order mapToOrder(OrderDTO orderDTO, OrderStatus status, LocalDateTime deliveryTime, LocalDateTime time) {
        Order order = new Order();

        order.setOrderId(orderDTO.OrderId());
        order.setStatus(status);
        order.setDistance(orderDTO.Distance());

        order.setItems(
                orderDTO.Items().stream()
                        .map(dto -> new OrderItem(dto.ItemId(), dto.Quantity()))
                        .toList()
        );

        order.setEstimatedDeliveryTime(deliveryTime);
        order.setNextUpdateTime(time);

        return order;
    }
}
