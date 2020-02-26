using System;
using System.IO;
using System.Text;

namespace Learning.IO
{
    public class MyFileStream
    {
        public void Process()
        {

            using (FileStream stream = new FileStream("OutputFile.txt", FileMode.Create, FileAccess.Write))
            {
                string message = "My beautiful message.";

                byte[] array = Encoding.UTF8.GetBytes(message);
                int position = 0;
                int length = message.Length;

                stream.Write(array, position, length);
            }

            using (FileStream stream = new FileStream("OutputFile.txt", FileMode.Append, FileAccess.Write))
            {
                string message = " My second part of my beautiful message";

                byte[] array = Encoding.UTF8.GetBytes(message);
                int position = 0;
                int length = message.Length;

                stream.Write(array, position, length);
            }

            using (FileStream stream = new FileStream("OutputFile.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] array = new byte[stream.Length];
                int position = 0;

                stream.Read(array, position, array.Length);

                Console.WriteLine(Encoding.UTF8.GetString(array));
            }

        }

        private static void ReadWithFileStream()
        {
            int bytesLength = 10;
            byte[] data = new byte[bytesLength];
            int position = 0;

            using (FileStream stream = new FileStream("EntityFrameworkTest.runtimeconfig.json", FileMode.Open, FileAccess.Read))
            {
                stream.Read(data, position, bytesLength);

                foreach (var item in data)
                {
                    System.Console.Write((char)item);
                }

                System.Console.WriteLine();

                stream.Read(data, position, bytesLength);

                foreach (var item in data)
                {
                    System.Console.Write((char)item);
                }

                System.Console.WriteLine();

                stream.Seek(5, SeekOrigin.Current);

                stream.Read(data, position, bytesLength);

                foreach (var item in data)
                {
                    System.Console.Write((char)item);
                }

                System.Console.WriteLine();

                stream.Seek(5, SeekOrigin.Begin);

                stream.Read(data, position, bytesLength);

                foreach (var item in data)
                {
                    System.Console.Write((char)item);
                }

                System.Console.WriteLine();

                stream.Position = 5;// same thing: stream.Seek(5, SeekOrigin.Begin);

                stream.Read(data, position, bytesLength);

                foreach (var item in data)
                {
                    System.Console.Write((char)item);
                }
            }
        }
    }
}
