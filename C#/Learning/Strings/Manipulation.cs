using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Learning.Strings
{
    public class Manipulation
    {
        public async void Test1()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            StringBuilder b = new StringBuilder();

            using (StringWriter writer = new StringWriter(b))
            {
                for (int i = 0; i < 50_000; i++)
                {
                    writer.WriteLine("ola meu querido amigo");
                }
            }

            using (StringReader reader = new StringReader(b.ToString()))
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds);
        }


    }
}
