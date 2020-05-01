using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTricks.Strings
{
    public class ChangeString
    {
        public unsafe void Process()
        {
            const String message = "I'm Iron Man";

            Console.WriteLine(message);

            fixed (char* pMessage = message)
            {
                char* p = pMessage;

                for (int i = 0; i < message.Length; i++)
                {
                    *p = '_';
                    p++;
                }
            }

            Console.WriteLine(message);
        }
    }
}
