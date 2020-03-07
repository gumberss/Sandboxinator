using System;
using System.Threading;

namespace DesignPatterns._3___Adapter
{
    public class Executor
    {
        public void Process()
        {
            ILog logger1 = new Logger();

            logger1.Log("I'm the default log");

            ILog logger2 = new LogAdapter(new IncompatibleLog());

            logger2.Log("Hey, I'm the incompatible log, but now I'm compatible :D");
        }

    }

    public interface IIncompatibleLog
    {
        void PresentMessage(String title, String message);
    }

    public interface ILog
    {
        void Log(String message);
    }

    public class Logger : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class IncompatibleLog : IIncompatibleLog
    {
        public void PresentMessage(string title, string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{title} - {message}");
        }
    }

    public class LogAdapter : ILog
    {
        private readonly IIncompatibleLog _incompatibleLog;

        public LogAdapter(IIncompatibleLog incompatibleLog)
        {
            _incompatibleLog = incompatibleLog;
        }

        public void Log(string message)
        {
            _incompatibleLog.PresentMessage(Thread.CurrentThread.Priority.ToString(), message);
        }
    }

}
