package com.maselniczka.restaurant_service.handler;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.maselniczka.restaurant_service.dtos.OrderDTO;
import com.maselniczka.restaurant_service.mapper.OrderMapper;
import com.maselniczka.restaurant_service.model.Order;
import com.maselniczka.restaurant_service.model.OrderStatus;
import com.maselniczka.restaurant_service.repository.OrderRepository;
import com.maselniczka.restaurant_service.service.EstimatedDeliveryTimeService;
import com.maselniczka.restaurant_service.service.NextUpdateTimeService;
import com.maselniczka.restaurant_service.service.OrderAcceptanceService;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;

@Service
@Slf4j
@RequiredArgsConstructor
public class MqttMessageHandler {
    private final OrderRepository orderRepository;
    private final ObjectMapper objectMapper;
    private final OrderMapper orderMapper;
    private final OrderAcceptanceService orderAcceptanceService;
    private final EstimatedDeliveryTimeService estimatedDeliveryTimeService;
    private final NextUpdateTimeService nextUpdateTimeService;

    public void Handle(String topic, String payload) {
        try {
            OrderDTO message = objectMapper.readValue(payload, OrderDTO.class);

            OrderStatus status = orderAcceptanceService.isOrderAccepted() ? OrderStatus.Accepted : OrderStatus.Cancelled;
            LocalDateTime estimatedDeliveryTime = status == OrderStatus.Accepted ? estimatedDeliveryTimeService.calculateDeliveryTime(message) : null;
            LocalDateTime nextUpdate = nextUpdateTimeService.getNextUpdateTime();

            Order order = orderMapper.mapToOrder(message, status, estimatedDeliveryTime, nextUpdate);

            orderRepository.save(order);

            log.debug("Order saved in database");
        } catch (Exception e) {
            log.error("Error while processing message. Topic: '{}', message: '{}'", topic, payload);
            log.debug(e.getMessage(), e);
        }
    }
}
