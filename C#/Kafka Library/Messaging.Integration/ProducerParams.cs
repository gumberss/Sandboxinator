namespace Messaging.Integration
{
    public record ProducerParams
    {
        public String Server { get; set; }


        public ProducerParams(string server)
        {
            Server = server;
        }
    }
}
