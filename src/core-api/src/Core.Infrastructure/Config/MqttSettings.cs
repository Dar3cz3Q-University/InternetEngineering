namespace Core.Infrastructure.Config
{
    public class MqttSettings
    {
        public const string SECTION_NAME = "MqttSettings";
        public string BrokerHost { get; init; } = null!;
        public int BrokerPort { get; init; } = 1883;
        public string ClientId { get; init; } = Guid.NewGuid().ToString();
        public string Username { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}