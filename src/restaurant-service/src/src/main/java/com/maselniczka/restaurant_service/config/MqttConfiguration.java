package com.maselniczka.restaurant_service.config;

import com.hivemq.client.mqtt.lifecycle.MqttClientAutoReconnect;
import com.hivemq.client.mqtt.mqtt5.Mqtt5AsyncClient;
import com.hivemq.client.mqtt.mqtt5.Mqtt5Client;
import com.hivemq.client.mqtt.mqtt5.message.auth.Mqtt5SimpleAuth;
import com.maselniczka.restaurant_service.exception.MqttClientConnectionException;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.boot.context.properties.EnableConfigurationProperties;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.util.UUID;
import java.util.concurrent.TimeUnit;

@Configuration
@EnableConfigurationProperties(MqttProperties.class)
@RequiredArgsConstructor
@Slf4j
public class MqttConfiguration {

    private final MqttProperties mqttProperties;

    private static final long AUTOMATIC_RECONNECT_INITIAL_DELAY_SECONDS = 5;
    private static final long AUTOMATIC_RECONNECT_MAX_DELAY_MINUTES = 3;
    private static final long SESSION_EXPIRY_INTERVAL_SECONDS = 300;

    @Bean
    public Mqtt5AsyncClient mqttClient() {
        var mqttClient = Mqtt5Client.builder()
                .identifier(UUID.randomUUID().toString())
                .serverHost(mqttProperties.getHost())
                .serverPort(mqttProperties.getPort())
                .simpleAuth(
                        Mqtt5SimpleAuth.builder()
                                .username(mqttProperties.getUsername())
                                .password(mqttProperties.getPassword().getBytes())
                                .build()
                )
                .automaticReconnect(
                        MqttClientAutoReconnect.builder()
                                .initialDelay(AUTOMATIC_RECONNECT_INITIAL_DELAY_SECONDS, TimeUnit.SECONDS)
                                .maxDelay(AUTOMATIC_RECONNECT_MAX_DELAY_MINUTES, TimeUnit.MINUTES)
                                .build()
                )
                .addConnectedListener(context -> log.info("Connected to MQTT Broker with context: {}", context))
                .addDisconnectedListener(context -> log.warn("Disconnected from MQTT Broker, cause: {}", context.getCause()))
                .buildAsync();

        mqttClient.connectWith()
                .cleanStart(false)
                .sessionExpiryInterval(SESSION_EXPIRY_INTERVAL_SECONDS)
                .send()
                .whenComplete((connAck, throwable) -> {
                    if (throwable != null) {
                        log.error("Error while connecting to MQTT Broker, error message: {}", throwable.getMessage());
                        log.debug(throwable.getMessage(), throwable);
                        throw new MqttClientConnectionException(throwable);
                    } else {
                        log.info("Successfully connected to MQTT Broker with connAck: {}", connAck);
                    }
                });

        return mqttClient;
    }
}
