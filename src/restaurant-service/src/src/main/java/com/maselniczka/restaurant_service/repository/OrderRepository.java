package com.maselniczka.restaurant_service.repository;

import com.maselniczka.restaurant_service.model.Order;
import org.springframework.data.mongodb.repository.MongoRepository;

public interface OrderRepository extends MongoRepository<Order, String> {
}
