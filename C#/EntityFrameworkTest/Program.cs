using Learning;
using Learning.AES;
using Learning.Boxes;
using Learning.CodeDOM;
using Learning.Events;
using Learning.Hash;
using Learning.Interfaces;
using Learning.IO;
using Learning.Reflection;
using Learning.Reflection.MySerializers;
using Learning.RegularExpressions;
using Learning.RSA;
using Learning.Serialization;
using Learning.Strings;
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
            var playing = new MyFileStream();

            playing.Process();
            
            Console.ReadKey();
        }
    }
}
