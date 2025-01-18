using ErrorOr;

namespace Core.Application.Common.Interfaces.Messaging
{
    public interface IMqttPublisher
    {
        Task PublishAsync(string topic, string payload);
    }
}