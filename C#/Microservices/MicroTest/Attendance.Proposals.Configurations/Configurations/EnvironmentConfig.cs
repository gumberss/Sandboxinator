using System;

namespace Attendance.Proposals.Configurations.Configurations
{
    public class EnvironmentConfig
    {
        //Db
        public String DbConnectionString { get; set; }

        //MessageBroker
        public string MsgBrokerHostName { get; set; }
        public string MsgBrokerUserName { get; set; }
        public string MsgBrokerPassword { get; set; }
        public int MsgBrokerPort { get; set; }
        public int MsgBrokerConnectionTimeout { get; set; }
    }
}