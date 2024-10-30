namespace Messaging.Integration
{
    public record ConsumerParams
    {
        public String? Server { get; set; }

        public String? GroupId { get; set; }

        public ConsumerParams(string? server, string? groupId)
        {
            Server = server;
            GroupId = groupId;
        }
    }
}
