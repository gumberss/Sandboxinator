using Messaging.Integration;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class ConsumerConfiguration
    {
        public static void AddConsumers(this IServiceCollection services)
        {
            var consumers = new Consumers();

            services.AddSingleton(new List<IConsumerSettings>
            {
                new ConsumerSettings<Banana>("test-topic-partitionss", consumers.ConsumeBanana)
            });
        }
    }

    public class ConsumerConfigurationsdf
    {
        public void AddConsumedsfrs(IServiceCollection services)
        {
            var consumers = new Consumers();

            services.AddSingleton(new List<IConsumerSettings>
            {
                new ConsumerSettings<Banana>("banana", consumers.ConsumeBanana)
            });
        }
    }
}
