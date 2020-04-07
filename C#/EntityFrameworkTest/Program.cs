using Learning;
using Learning.AES;
using Learning.Assemblies;
using Learning.Boxes;
using Learning.CodeDOM;
using Learning.Enums;
using Learning.Events;
using Learning.Events.EventTest;
using Learning.Exceptions;
using Learning.Fors;
using Learning.Hash;
using Learning.HTTP;
using Learning.IndexNotations;
using Learning.Interfaces;
using Learning.IO;
using Learning.Reflection;
using Learning.Reflection.MySerializers;
using Learning.RegularExpressions;
using Learning.RSA;
using Learning.Serialization;
using Learning.SImpleTests;
using Learning.Strings;
using Learning.Structs;
using Learning.Threads;
using Learning.Threads.BusinessRules;
using Learning.TypeAndCollections;
using Learning.ReaderAndWriter;
using System;
using Learning.Transactions;

namespace EntityFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var playing = new MyTransactions();

            playing.Process();
            
            Console.ReadKey();
        }
    }
}
