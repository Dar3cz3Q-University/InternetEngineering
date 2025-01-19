package com.maselniczka.restaurant_service.service;

import com.maselniczka.restaurant_service.config.EstimatedDeliveryTimeConfig;
import com.maselniczka.restaurant_service.dtos.OrderDTO;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.Random;

@Service
@RequiredArgsConstructor
public class EstimatedDeliveryTimeService {

    private final EstimatedDeliveryTimeConfig config;
    private final Random random = new Random();

    public LocalDateTime calculateDeliveryTime(OrderDTO order) {
        long timeForDelivery = (long) (order.Distance() * config.getTimePerKm());
        long timeForPreparing = 0;

        for (var item : order.Items())
            timeForPreparing += (long) (item.Quantity() * config.getTimePerProduct());

        long randomTime = random.nextLong(config.getRandomRange());

        return LocalDateTime.now().plusSeconds(timeForDelivery + timeForPreparing + randomTime);
    }
}
