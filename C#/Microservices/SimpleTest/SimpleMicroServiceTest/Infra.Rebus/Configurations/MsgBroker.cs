using System;

namespace Infra.Rebus.Configurations
{
    public class MsgBroker
    {
        public String Username { get; set; }

        public String Password { get; set; }

        public String HostName { get; set; }

        public int Port { get; set; }

    }
}
