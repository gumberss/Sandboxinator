# How to configure a Kafka Cluster

## Docker Compose

![image](https://github.com/user-attachments/assets/b1c84d7f-7f5b-430f-aeec-96c330670692)


### References

https://hub.docker.com/r/bitnami/kafka

https://github.com/bitnami/containers/blob/main/bitnami/kafka/README.md#accessing-apache-kafka-with-internal-and-external-clients

https://rmoff.net/2018/08/02/kafka-listeners-explained/

https://stackoverflow.com/questions/78022451/how-to-run-ksqldb-along-with-kafka-server-using-docker-compose

https://stackoverflow.com/questions/68586043/connection-to-kafka-broker-in-docker-container-fails

## Topic config

Set the boostrap servers as the servers you configured in your cluseter

```cs
var bootstrapServers = "localhost:9092,localhost:9093,localhost:9094";
```

To avoid create the topic when a event is produced to the partition, it's recomended that we create the partition first, so here is the code to create the topic with 3 partitions and with the replication factor as 3 as well:

```cs
using (var adminClient = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = bootstrapServers }).Build())
{
    try
    {
        await adminClient.CreateTopicsAsync(new TopicSpecification[] {
                    new TopicSpecification { Name = topicName, ReplicationFactor = 3, NumPartitions = 3 } });
    }
    catch (CreateTopicsException e)
    {
        Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
    }
}
```

With the topic and the partitions created, we can safelly produce events

````cs
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
                // the key here is a random guid, but you can test with a static value and se that the event will always go to the same partition
                // with the random guid it go to different partitions
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
```

Once the events are produced, you can consume them

```cs
async Task Consumer(String name, CancellationToken ca)
{
    var conf = new ConsumerConfig
    {
        GroupId = "test-consumer-group", // same ocnsumer group, to ensure the event will be processed one time,
                                         // If you want the same event be processed many times, you can change the group-id
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
```
