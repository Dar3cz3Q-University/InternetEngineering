package com.maselniczka.restaurant_service.model;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;
import org.springframework.data.annotation.Id;

@Setter
@Getter
@AllArgsConstructor
public class OrderItem {

    @Id
    private String ItemId;
    private double Quantity;
}
