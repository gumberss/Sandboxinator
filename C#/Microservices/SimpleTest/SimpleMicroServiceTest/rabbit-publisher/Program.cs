using System;
using System.Text;
using RabbitMQ.Client;

namespace rabbit_publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var body = Encoding.UTF8.GetBytes("Hiiiiiiiiiiiiiiiiiiiiiiiii");

                Console.ReadKey();

                channel.BasicPublish(exchange: "exchange",
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
            }
        }
    }
}
