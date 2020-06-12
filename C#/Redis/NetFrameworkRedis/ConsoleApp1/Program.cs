using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = redis.GetDatabase();

                var data = db.StringGet("batman");

                var dataHash = db.HashGetAll("batmanHash");

                var batmanType = db.HashGet("batmanHash", "type");
                var batmanName = db.HashGet("batmanHash", "Name");


                Console.WriteLine(data);
            }
        }
    }
}
