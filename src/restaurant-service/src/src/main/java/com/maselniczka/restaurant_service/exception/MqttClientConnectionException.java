package com.maselniczka.restaurant_service.exception;

import org.springframework.http.HttpStatus;

public class MqttClientConnectionException extends RuntimeException {

    private static final String ERROR_MESSAGE = "Error while connecting to MQTT broker";

    public MqttClientConnectionException(Throwable cause) {
        super(ERROR_MESSAGE, cause);
    }

    public HttpStatus getHttpStatus() {
        return HttpStatus.INTERNAL_SERVER_ERROR;
    }
}
