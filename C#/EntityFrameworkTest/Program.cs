using Learning;
using Learning.AES;
using Learning.Events;
using Learning.RegularExpressions;
using Learning.Serialization;
using Learning.Threads;
using Learning.Threads.BusinessRules;
using Learning.TypeAndCollections;
using System;

namespace EntityFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var playing = new MyAes();

            playing.Process();
            
            Console.ReadKey();
        }
    }
}
