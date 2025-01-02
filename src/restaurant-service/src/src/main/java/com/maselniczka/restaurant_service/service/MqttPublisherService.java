package com.maselniczka.restaurant_service.service;

import com.hivemq.client.mqtt.datatypes.MqttQos;
import com.hivemq.client.mqtt.mqtt5.Mqtt5AsyncClient;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;

@Service
@Slf4j
@RequiredArgsConstructor
public class MqttPublisherService {

    private final Mqtt5AsyncClient mqttClient;
    private final MqttTopicService mqttTopicService;

    private void publish(String topic, byte[] message) {
        mqttClient.publishWith()
                .topic(mqttTopicService.getTopic(topic))
                .qos(MqttQos.AT_LEAST_ONCE)
                .payload(message)
                .send()
                .whenComplete((pubRes, throwable) -> {
                    if (throwable != null) {
                        log.error("Error while publishing message to: [{}] topic, error: {}", topic, throwable.getMessage());
                        log.debug(throwable.getMessage(), throwable);
                    } else {
                        log.info("Published message: {}", pubRes);
                    }
                });
    }
}
