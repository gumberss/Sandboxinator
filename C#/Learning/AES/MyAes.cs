using System;
using System.IO;
using System.Security.Cryptography;

namespace Learning.AES
{
    public class MyAes
    {
        public void Process()
        {
            String secret = "I need to protect it";

            byte[] encrypted, key;

            using (Aes aes = Aes.Create())
            {
                Console.WriteLine(secret);

                key = aes.Key;

                ICryptoTransform cryptoTransform = aes.CreateEncryptor();

                using MemoryStream ms = new MemoryStream();
                using CryptoStream cryptoStream = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write);
                using StreamWriter sw = new StreamWriter(cryptoStream);

                sw.Write(secret);

                encrypted = ms.ToArray();
            }

            ShowBytes("Key: ", key);
            ShowBytes("Encrypted: ", encrypted);
        }

        public void ShowBytes(String title, byte[] bytes)
        {
            Console.Write(title);

            foreach (var b in bytes)
            {
                Console.Write("{0:x} ", b);
            }
            Console.WriteLine();
        }
    }
}
