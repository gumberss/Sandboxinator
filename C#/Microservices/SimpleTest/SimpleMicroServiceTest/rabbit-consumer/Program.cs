using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace rabbit_consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "test",
                Password = "test"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "exchange", type: ExchangeType.Fanout, durable: true);

                var queueName = channel.QueueDeclare("my_queue", durable: true).QueueName;

                channel.QueueBind(queue: queueName,
                              exchange: "exchange",
                              routingKey: "");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());
                    Console.WriteLine(" [x] {0}", message);
                };

                channel.BasicConsume(queue: queueName,
                                autoAck: true,
                                consumer: consumer);

                Console.ReadKey();
            }
        }
    }
}
