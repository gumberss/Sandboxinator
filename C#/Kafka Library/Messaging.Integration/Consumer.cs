using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Messaging.Integration
{
    public class Consumer : BackgroundService
    {
        List<Task> tasks = new List<Task>();
        private readonly IConfiguration _configuration;
        private readonly Dictionary<string, IConsumerSettings> _consumerSettings;
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly ConsumerConfig _consumerConfig;

        public Consumer(IConfiguration configuration, List<IConsumerSettings> consumerSettings)
        {
            var parameters = new ConsumerParams(configuration["Messaging:Servers"], configuration["Messaging:GroupId"]);

            if (parameters.Server is null)
                throw new Exception("Messageing server is null, configure the Messaging:Servers on the appsettings");

            if (parameters.GroupId is null)
                throw new Exception("Messageing GroupId is null, configure the Messaging:GroupId on the appsettings");

            _consumerConfig = new ConsumerConfig
            {
                GroupId = parameters.GroupId,
                BootstrapServers = parameters.Server,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _configuration = configuration;
            _consumerSettings = consumerSettings.ToDictionary(x => x.Topic);

            _consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            foreach (var settings in _consumerSettings.Keys)
                _consumer.Subscribe(settings);

            while (!stoppingToken.IsCancellationRequested)
            {
                var cr = _consumer.Consume(stoppingToken);

                var eventConsumer = _consumerSettings[cr.Topic];

                eventConsumer?.Consume(cr.Message.Value);
            }

            _consumer.Close();
        }


        public override void Dispose()
        {
            base.Dispose();
            _consumer.Dispose();
        }
    }
}
