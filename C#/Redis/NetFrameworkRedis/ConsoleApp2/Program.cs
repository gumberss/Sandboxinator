using System;
using StackExchange.Redis;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            SetString();
            HashSet();

        }

        private static void SetString()
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = redis.GetDatabase();

                var data = db.StringSet("batman", "batman2");

                Console.WriteLine(data);
            }
        }


        private static void HashSet()
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = redis.GetDatabase();

                var a = new HashEntry("type", "bat");
                var b = new HashEntry("Name", "I don't know");

                db.HashSet("batmanHash", new[] { a, b });
            }
        }
    }
}
