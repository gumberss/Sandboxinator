using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.ReaderAndWriter
{
    public class MyBinaryReader
    {
        public void Process()
        {
            using (var stream = System.IO.File.OpenWrite("Binary.dat"))
            using (var writer = new System.IO.BinaryWriter(stream))
            {
                for (int i = 0; i < 4; i++)
                {
                    writer.Write($"Hello: {i}");
                }
            }


            using (var fileStream = System.IO.File.OpenRead("Binary.dat"))
            using (System.IO.BinaryReader reader = new System.IO.BinaryReader(fileStream))
            {
                for (int i = 0; i < 4; i++)
                {
                    String data = reader.ReadString();

                    Console.WriteLine(data);
                }
            }


        }
    }

}
