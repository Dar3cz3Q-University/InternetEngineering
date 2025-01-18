using Core.Application.Common.Interfaces.Messaging;
using Core.Infrastructure.Config;
using Microsoft.Extensions.Options;
using MQTTnet;
using System.Text;

// TODO: Add logging
namespace Core.Infrastructure.Messaging
{
    public class MqttPublisher : IMqttPublisher, IDisposable
    {
        private readonly IMqttClient _client;
        private readonly MqttClientOptions _options;

        public MqttPublisher(IOptions<MqttSettings> options)
        {
            var settings = options.Value;

            var factory = new MqttClientFactory();
            _client = factory.CreateMqttClient();

            var optionsBuilder = new MqttClientOptionsBuilder()
                .WithTcpServer(settings.BrokerHost, settings.BrokerPort)
                .WithClientId(settings.ClientId + "-publisher")
                .WithCleanStart(true);

            if (!string.IsNullOrEmpty(settings.Username) && !string.IsNullOrEmpty(settings.Password))
                optionsBuilder.WithCredentials(settings.Username, settings.Password);

            _options = optionsBuilder.Build();
        }

        public async Task PublishAsync(string topic, string payload)
        {
            if (!_client.IsConnected)
            {
                await _client.ConnectAsync(_options, CancellationToken.None);
            }

            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(Encoding.UTF8.GetBytes(payload))
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();

            await _client.PublishAsync(message, CancellationToken.None);
        }

        public void Dispose()
        {
            if (_client.IsConnected)
                _client.DisconnectAsync().GetAwaiter().GetResult();

            _client?.Dispose();
        }
    }
}