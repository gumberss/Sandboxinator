using System;
using StackExchange.Redis;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = redis.GetDatabase();

                //db.StringSet("batman", "lalapo");

                var data = db.StringGet("batman");

                Console.WriteLine(data);
            }



        }
    }
}
