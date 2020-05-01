using System;
using System.Threading;
using MemoryTricks.BoxingAndUnboxing;
using MemoryTricks.Strings;

namespace MemoryTricks
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new ChangeString();

            player.Process();
        }
    }
}
