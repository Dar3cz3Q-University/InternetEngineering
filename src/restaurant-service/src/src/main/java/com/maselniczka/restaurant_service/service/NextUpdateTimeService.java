package com.maselniczka.restaurant_service.service;

import com.maselniczka.restaurant_service.config.OrderUpdateConfig;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.Random;

@Service
@RequiredArgsConstructor
public class NextUpdateTimeService {

    private final OrderUpdateConfig config;
    private final Random random = new Random();

    public LocalDateTime getNextUpdateTime() {
        var addSeconds = random.nextLong(config.getNextUpdateTimeMin(), config.getNextUpdateTimeMax());

        return LocalDateTime.now().plusSeconds(addSeconds);
    }
}
