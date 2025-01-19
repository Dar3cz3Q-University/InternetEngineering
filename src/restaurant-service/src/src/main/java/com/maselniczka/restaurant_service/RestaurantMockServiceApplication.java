package com.maselniczka.restaurant_service;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.scheduling.annotation.EnableScheduling;

@SpringBootApplication
@EnableScheduling
public class RestaurantMockServiceApplication {

	public static void main(String[] args) {
		SpringApplication.run(RestaurantMockServiceApplication.class, args);
	}

}
