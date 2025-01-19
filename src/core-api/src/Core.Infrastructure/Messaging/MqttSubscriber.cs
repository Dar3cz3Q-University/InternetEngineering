using Core.Application.Common.Interfaces.Messaging;
using Core.Infrastructure.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQTTnet;
using MQTTnet.Packets;
using System.Text;

namespace Core.Infrastructure.Messaging
{
    public class MqttSubscriber : IHostedService, IDisposable
    {
        private readonly int RECONNECT_DELAY_SECONDS = 5;
        private readonly string TOPIC = "/maslo/orders/+/update"; // TODO: Move to a different file
        private readonly IMqttClient _client;
        private readonly MqttClientOptions _options;
        private readonly IServiceProvider _serviceProvider;

        public MqttSubscriber(
            MqttSettings settings,
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new MqttClientFactory();
            _client = factory.CreateMqttClient();

            var optionsBuilder = new MqttClientOptionsBuilder()
                .WithTcpServer(settings.BrokerHost, settings.BrokerPort)
                .WithClientId(settings.ClientId + "-subscriber")
                .WithCleanStart(true);

            if (!string.IsNullOrEmpty(settings.Username) && !string.IsNullOrEmpty(settings.Password))
                optionsBuilder.WithCredentials(settings.Username, settings.Password);

            _options = optionsBuilder.Build();

            _client.ApplicationMessageReceivedAsync += OnMessageReceived;

            _client.DisconnectedAsync += OnDisconnectedAsync;
        }

        private async Task ConnectWithRetryAsync()
        {
            while (true)
            {
                if (!_client.IsConnected)
                {
                    try
                    {
                        await _client.ConnectAsync(_options);
                        Console.WriteLine("MQTT Client connected.");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Connection failed: {ex.Message}. Retrying in 5 seconds...");
                        await Task.Delay(TimeSpan.FromSeconds(RECONNECT_DELAY_SECONDS));
                    }
                }
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine("Łączenie z brokerem MQTT...");
                await _client.ConnectAsync(_options, cancellationToken);
                Console.WriteLine("Połączono z brokerem MQTT.");

                await _client.SubscribeAsync(new MqttTopicFilter
                {
                    Topic = TOPIC,
                    QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce
                });
                Console.WriteLine($"Subskrybowany temat: {TOPIC}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas łączenia lub subskrypcji: {ex.Message}");
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Rozłączanie z brokerem MQTT...");
            if (_client.IsConnected)
            {
                await _client.DisconnectAsync();
            }
        }

        private async Task OnMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            Console.WriteLine($"Otrzymano wiadomość z tematu '{e.ApplicationMessage.Topic}': {payload}");

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var messageHandler = scope.ServiceProvider.GetRequiredService<IMqttMessageHandler>();

                await messageHandler.HandleMessageAsync(e.ApplicationMessage.Topic, payload);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas przetwarzania wiadomości MQTT: {ex.Message}");
            }
        }

        private async Task OnDisconnectedAsync(MqttClientDisconnectedEventArgs args)
        {
            Console.WriteLine("Disconnected from MQTT broker.");
            if (args.ClientWasConnected)
            {
                Console.WriteLine("Attempting to reconnect...");
                await ConnectWithRetryAsync();
            }
        }

        public void Dispose()
        {
            if (_client.IsConnected)
            {
                _client.DisconnectAsync().GetAwaiter().GetResult();
            }

            _client?.Dispose();
        }
    }
}
