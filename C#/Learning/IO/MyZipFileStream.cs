using System;
using System.IO;
using System.IO.Compression;

namespace Learning.IO
{
    public class MyZipFileStream
    {
        public async void Process()
        {
            using (FileStream fs = new FileStream("text.zip", FileMode.OpenOrCreate, FileAccess.Write))
            using (GZipStream zipper = new GZipStream(fs, CompressionMode.Compress))
            using (StreamWriter writer = new StreamWriter(zipper))
            {
                await writer.WriteAsync("Hello!!!");
            }

            using (FileStream fs = new FileStream("text.zip", FileMode.Open, FileAccess.Read))
            using (GZipStream zipper = new GZipStream(fs, CompressionMode.Decompress))
            using (StreamReader reader = new StreamReader(zipper))
            {
                string text = await reader.ReadToEndAsync();
                Console.WriteLine(text);
            }
        }
    }
}
