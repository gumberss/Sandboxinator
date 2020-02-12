using Learning;
using Learning.Events;
using Learning.Serialization;
using Learning.Threads;
using Learning.Threads.BusinessRules;
using System;

namespace EntityFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var playing = new MyXmlSerializer();

            Console.WriteLine(playing.Serialize(new Street()));

            Console.ReadKey();
        }
    }
}
