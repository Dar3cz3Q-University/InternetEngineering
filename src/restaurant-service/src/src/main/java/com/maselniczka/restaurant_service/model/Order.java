package com.maselniczka.restaurant_service.model;

import lombok.Getter;
import lombok.Setter;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.time.LocalDateTime;
import java.util.List;

@Document(collection = "orders")
@Setter
@Getter
public class Order {

    @Id
    private String id;

    private String OrderId;
    private OrderStatus Status;
    private double Distance;
    private List<OrderItem> Items;
    private LocalDateTime EstimatedDeliveryTime;
    private LocalDateTime NextUpdateTime;
}
