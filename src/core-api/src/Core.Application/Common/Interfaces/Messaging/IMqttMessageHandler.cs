namespace Core.Application.Common.Interfaces.Messaging
{
    public interface IMqttMessageHandler
    {
        Task HandleMessageAsync(string topic, string payload);
    }
}