package com.maselniczka.restaurant_service.service;

import org.springframework.stereotype.Service;

import java.util.Random;

@Service
public class OrderAcceptanceService {

    private final Random random = new Random();

    public boolean isOrderAccepted() {
        int randomValue = random.nextInt(100);
        return randomValue < 90;
    }
}
