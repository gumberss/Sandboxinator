using System;
using System.Threading.Tasks;
using Consumer;
using Infra.Rebus.Configurations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Handlers;
using SimpleInjector;
using Infra.Rebus.Messages;
using Rebus.SimpleInjector;
using System.Reflection;
using Rebus.Activation;

namespace MainProject
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
                activator.Register(() => new ConsumerHandler());

                Configure.With(activator)
                    .Transport(x => x.UseRabbitMq($"amqp://{msgBroker.Username}:{msgBroker.Password}@{msgBroker.HostName}:{msgBroker.Port}/", "consumer"))
                    .Start();

                activator.Bus.Subscribe<Batman>().Wait();

                Console.ReadKey();
            }

            Console.WriteLine("Quit");
        }
    }
}
