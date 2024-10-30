using Confluent.Kafka;
using System.Text.Json;

namespace Messaging.Integration
{
    public class Producer
    {
        private readonly IProducer<string, string> producer;

        public Producer(ProducerParams parameters)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = parameters.Server,
            };

            producer = new ProducerBuilder<String, string>(config).Build();

        }
        public async Task Produce<T>(MessageProductionParams<T> parameters, Action<Exception> onError)
        {
            try
            {
                var dr = await producer.ProduceAsync(parameters.Topic, new Message<String, string> { Key = parameters.OrderKey, Value = JsonSerializer.Serialize(parameters.Data) });
                Console.WriteLine($"Delivered '{dr.Key}' to '{dr.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                onError(e);
            }
        }
    }
}
