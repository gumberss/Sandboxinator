using Rebus.Activation;
using Rebus.Config;

namespace Infra.Rebus.Configurations
{
    public static class Config
    {
        public static BuiltinHandlerActivator Do(MsgBroker conn)
        {
            var adapter = new BuiltinHandlerActivator();

            Configure
                .With(adapter)
                .Transport(x => x.UseRabbitMq($"amqp://{conn.Username}:{conn.Password}@{conn.HostName}:{conn.Port}/", "input_queue"))
                .Start();

            return adapter;
        }
    }
}
