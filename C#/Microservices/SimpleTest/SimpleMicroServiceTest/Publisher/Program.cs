using System;
using System.Reflection;
using Infra.Rebus.Configurations;
using Infra.Rebus.Messages;
using Rebus.Activation;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;
using Rebus.SimpleInjector;
using SimpleInjector;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var msgBroker = new MsgBroker
            {
                HostName = "localhost",
                Password = "test",
                Username = "test",
                Port = 5672
            };

            using (var activator = new BuiltinHandlerActivator())
            {
                var bus = Configure.With(activator)
                    .Transport(x => x.UseRabbitMqAsOneWayClient($"amqp://{msgBroker.Username}:{msgBroker.Password}@{msgBroker.HostName}:{msgBroker.Port}/"))
                    .Start();

                while (true)
                {
                    var key = Console.ReadKey();

                    bus.Publish(new Batman {  Message = "Batman" });

                    if (key.KeyChar == 'q') break;
                }
            }

            Console.ReadKey();
            Console.WriteLine("Quit");
        }
    }
}
