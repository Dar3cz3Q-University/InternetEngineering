package com.maselniczka.restaurant_service.service;

import com.maselniczka.restaurant_service.config.MqttProperties;
import org.springframework.stereotype.Service;

@Service
public class MqttTopicService {

    public String getTopic(String topic) {
        return String.format(MqttProperties.TOPIC_TEMPLATE, topic);
    }
}
