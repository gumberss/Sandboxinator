using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace LearningFramework.EventLogs
{
    public class MyEventLog
    {
        public void Process()
        {
            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "AppCenter");
            }

            EventLog.WriteEntry("MySource", "A static Error", EventLogEntryType.Error);
            EventLog.WriteEntry("MySource", "A static Information", EventLogEntryType.Information);
            EventLog.WriteEntry("MySource", "A static Warning", EventLogEntryType.Warning);

            EventLog myLogger = new EventLog("AppCenter");
            
            myLogger.Source = "MySource";

            myLogger.WriteEntry("An Error", EventLogEntryType.Error);
            myLogger.WriteEntry("A Information", EventLogEntryType.Information);
            myLogger.WriteEntry("A Warning", EventLogEntryType.Warning);
        }
    }
}
