using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Learning.Hash
{
    public class MyHash
    {
        public void Process()
        {
            UTF8Encoding encoding = new UTF8Encoding();

            var messageBytes = encoding.GetBytes("My message");

            var algorithm = SHA256.Create();

            var hash = algorithm.ComputeHash(messageBytes);

            hash.ToList().ForEach(x => Console.Write($"{x} "));
        }
    }
}
