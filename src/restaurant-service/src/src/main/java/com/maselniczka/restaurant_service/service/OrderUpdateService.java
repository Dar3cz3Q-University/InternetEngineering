package com.maselniczka.restaurant_service.service;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.maselniczka.restaurant_service.mapper.MessageMapper;
import com.maselniczka.restaurant_service.messages.OrderUpdateMessage;
import com.maselniczka.restaurant_service.model.Order;
import com.maselniczka.restaurant_service.model.OrderStatus;
import com.maselniczka.restaurant_service.repository.OrderRepository;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.List;

@Slf4j
@Service
@RequiredArgsConstructor
public class OrderUpdateService {

    private final ObjectMapper objectMapper;
    private final OrderRepository orderRepository;
    private final MqttPublisherService mqttPublisherService;
    private final MessageMapper messageMapper;
    private final NextUpdateTimeService nextUpdateTimeService;

    @Scheduled(fixedRateString = "${order-update.update-fixed-rate}")
    public void Update() throws InterruptedException, JsonProcessingException {
        log.info("Running order updates");

        List<Order> orders = orderRepository.findAll();

        for (var order : orders) {
            if (order.getNextUpdateTime().isAfter(LocalDateTime.now()))
                continue;

            boolean remove = order.getStatus() == OrderStatus.Cancelled || order.getStatus() == OrderStatus.ReadyForCollection;

            OrderUpdateMessage message = messageMapper.mapToMessage(order);

            mqttPublisherService.publish(message.OrderId(), objectMapper.writeValueAsBytes(message));

            LocalDateTime nextUpdate = nextUpdateTimeService.getNextUpdateTime();

            order.setNextUpdateTime(nextUpdate);
            order.setStatus(order.getStatus().next());

            if (remove) {
                log.info("Removing order from database");
                orderRepository.delete(order);
            } else {
                log.info("Updating order in database");
                orderRepository.save(order);
            }

            Thread.sleep(100);
        }
    }
}
