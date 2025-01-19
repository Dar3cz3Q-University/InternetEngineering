package com.maselniczka.restaurant_service.config;

import lombok.Getter;
import lombok.Setter;
import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.context.annotation.Configuration;

@Configuration
@ConfigurationProperties(prefix = "order-update")
@Getter
@Setter
public class OrderUpdateConfig {

    private long nextUpdateTimeMin;
    private long nextUpdateTimeMax;
}
