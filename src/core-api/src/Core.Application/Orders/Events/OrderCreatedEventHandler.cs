using Core.Application.Common.Dtos;
using Core.Application.Common.Interfaces.Messaging;
using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.OrderAggregate.Events;
using MapsterMapper;
using MediatR;
using System.Text.Json;

namespace Core.Application.Orders.Events
{
    public class OrderCreatedEventHandler
        : INotificationHandler<OrderCreated>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMqttPublisher _mqttPublisher;
        private readonly IMapper _mapper;

        public OrderCreatedEventHandler(
            IAddressRepository addressRepository,
            IRestaurantRepository restaurantRepository,
            IMqttPublisher mqttPublisher,
            IMapper mapper)
        {
            _addressRepository = addressRepository;
            _restaurantRepository = restaurantRepository;
            _mqttPublisher = mqttPublisher;
            _mapper = mapper;
        }

        public async Task Handle(
            OrderCreated notification,
            CancellationToken cancellationToken)
        {
            // TODO: Check for errors

            var deliveryAddress = await _addressRepository.GetByIdAsync(notification.Order.DeliveryAddressId);

            var restaurant = await _restaurantRepository.GetByIdAsync(notification.Order.RestaurantId);

            var distance = deliveryAddress.Value.CalculateDistance(restaurant.Value.Location.Latitude, restaurant.Value.Location.Longitude);

            var message = _mapper.Map<OrderCreatedMessageDTO>((notification.Order, distance));

            var payload = JsonSerializer.Serialize(message);

            var topic = $"/maslo/orders/{notification.Order.Id.Value}/new"; // TODO: Move to a different file

            await _mqttPublisher.PublishAsync(topic, payload);
        }
    }
}