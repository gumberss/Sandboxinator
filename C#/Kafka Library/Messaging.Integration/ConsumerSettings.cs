using System.Text.Json;

namespace Messaging.Integration
{
    public class ConsumerSettings<T> : IConsumerSettings where T : class
    {
        public String Topic { get; private set; }
        public Action<String> Consume { get; }
            
        public ConsumerSettings(string topic, Action<T?> consume)
        {
            Topic = topic;
            Consume = (string json) =>
            {
                var data = JsonSerializer.Deserialize<T?>(json);
                consume(data);
            };
        }
    }
}
