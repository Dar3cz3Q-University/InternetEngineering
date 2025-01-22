using Core.Application.Common.Dtos;
using Core.Application.Common.Interfaces.Messaging;
using Core.Application.Common.Interfaces.Persistance;
using Core.Domain.OrderAggregate.ValueObjects;
using System.Text.Json;

namespace Core.Application.Services
{
    public class MqttMessageHandler : IMqttMessageHandler
    {
        private readonly IOrderRepository _orderRepository;

        public MqttMessageHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task HandleMessageAsync(string topic, string payload)
        {
            var message = JsonSerializer.Deserialize<OrderUpdateMessageDTO>(payload);

            if (message is null)
            {
                Console.WriteLine($"Błąd: Nie można zdeserializować wiadomości. Payload: {payload}");
                return;
            }

            var orderId = OrderId.Create(message.OrderId);

            var orderResult = await _orderRepository.GetByIdAsync(orderId);
            var order = orderResult.Value;

            if (order is not null)
            {
                order.SetOrderStatus(message.OrderStatus);
                order.SetDeliveryDateTime(message?.DeliveryDateTime);

                await _orderRepository.UpdateAsync(order);
            }
            else
            {
                Console.WriteLine($"Nie znaleziono encji o ID: {message.OrderId}");
            }
        }
    }
}