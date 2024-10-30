namespace Messaging.Integration
{
    public class MessageProductionParams<T>
    {
        public String Topic { get; private set; }
        public String OrderKey { get; private set; }
        public T Data { get; private set; }

        public MessageProductionParams(string topic, string orderKey, T data)
        {
            Topic = topic;
            OrderKey = orderKey;
            Data = data;
        }
    }
}
