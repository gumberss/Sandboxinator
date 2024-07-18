// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using Confluent.Kafka.Admin;

var topicName = "test-topic-partitionss";
var bootstrapServers = "localhost:9092,localhost:9093,localhost:9094";
 using (var adminClient = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = bootstrapServers }).Build())
{
    try
    {
        await adminClient.CreateTopicsAsync(new TopicSpecification[] {
                    new TopicSpecification { 
                        Configs =  new Dictionary<string, string>
                        { 
                        },
                        Name = topicName, ReplicationFactor = 3, NumPartitions = 3 } });
    }
    catch (CreateTopicsException e)
    {
        Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
    }
}


Console.WriteLine("Hello, World!");
//https://www.nuget.org/packages/Confluent.Kafka/
async Task Producer()
{
    

    var config = new ProducerConfig { BootstrapServers = bootstrapServers };

    // If serializers are not specified, default serializers from
    // `Confluent.Kafka.Serializers` will be automatically used where
    // available. Note: by default strings are encoded as UTF8.
    using (var p = new ProducerBuilder<String, string>(config).Build())
    {
        while (true)
        {
            try
            {
                var dr = await p.ProduceAsync(topicName, new Message<String, string> { Key = Guid.NewGuid().ToString(), Value = "test" });
                Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
            Thread.Sleep(500);
        }
    }
}

var p = Task.Run(Producer);

async Task Consumer(String name, CancellationToken ca)
{
    var conf = new ConsumerConfig
    {
        GroupId = "test-consumer-group",
        BootstrapServers = bootstrapServers,
        // Note: The AutoOffsetReset property determines the start offset in the event
        // there are not yet any committed offsets for the consumer group for the
        // topic/partitions of interest. By default, offsets are committed
        // automatically, so in this example, consumption will only start from the
        // earliest message in the topic 'my-topic' the first time you run the program.
        AutoOffsetReset = AutoOffsetReset.Earliest
    };

    using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
    {
        c.Subscribe(topicName);

        CancellationTokenSource cts = new CancellationTokenSource();
        Console.CancelKeyPress += (_, e) =>
        {
            // Prevent the process from terminating.
            e.Cancel = true;
            cts.Cancel();
        };

        try
        {
            while (!ca.IsCancellationRequested)
            {
                try
                {
                    var cr = c.Consume(cts.Token);
                    Console.WriteLine($"{name}' at: '{cr.TopicPartitionOffset}'.");
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Error occured: {e.Error.Reason}");
                }
            }

            c.Close();
        }
        catch (OperationCanceledException)
        {
            // Ensure the consumer leaves the group cleanly and final offsets are committed.
            c.Close();
        }
    }
}


var cancelationToken = new CancellationTokenSource();

var c1 = Task.Run(() => Consumer("One ", cancelationToken.Token));
Console.WriteLine("SIMBORA Q PA");


Thread.Sleep(5000);

var c2 = Task.Run(() => Consumer("Two ", cancelationToken.Token));
Console.WriteLine("SIMBORA Q PA");

Thread.Sleep(5000);

var c3 = Task.Run(() => Consumer("Three ", cancelationToken.Token));
Console.WriteLine("SIMBORA Q PA");


Thread.Sleep(int.MaxValue);


