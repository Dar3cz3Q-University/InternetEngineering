package com.maselniczka.restaurant_service.config;

import lombok.AllArgsConstructor;
import lombok.Getter;
import org.springframework.boot.context.properties.ConfigurationProperties;

@ConfigurationProperties(prefix = "mqtt")
@AllArgsConstructor
@Getter
public final class MqttProperties {

    public static final String ROOT_TOPIC = "/maslo/orders/+/new";
    public static final String TOPIC_TEMPLATE = "/maslo/orders/%s/update";

    private String host;
    private int port;
    private String username;
    private String password;
}