using System.IO;

namespace Learning.IO
{
    public class MyFileStream
    {
        public void Process()
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
