package com.maselniczka.restaurant_service.service;

import com.hivemq.client.mqtt.MqttGlobalPublishFilter;
import com.hivemq.client.mqtt.datatypes.MqttQos;
import com.hivemq.client.mqtt.mqtt5.Mqtt5AsyncClient;
import com.maselniczka.restaurant_service.config.MqttProperties;
import jakarta.annotation.PostConstruct;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;

@Service
@Slf4j
@RequiredArgsConstructor
public class MqttSubscriberService {

    private final Mqtt5AsyncClient mqttClient;

    private void subscribe() {
        mqttClient.publishes(MqttGlobalPublishFilter.SUBSCRIBED, context -> log.info("New message published on: {}", context.getTopic()));

        mqttClient.subscribeWith()
                .topicFilter(MqttProperties.ROOT_TOPIC)
                .qos(MqttQos.AT_LEAST_ONCE)
                .callback(x -> {
                    log.info("New message");
                })
                .send()
                .whenComplete((subAck, throwable) -> {
                    if (throwable != null) {
                        log.error("Error while subscribing: {}", throwable.getMessage());
                    } else {
                        log.info("Successfully subscribed to: {}", subAck);
                    }
                });
    }

    @PostConstruct
    public void init() {
        try {
            subscribe();
        } catch(Exception e) {
            e.printStackTrace();
        }
    }
}
