using System;
using System.IO;
using System.Security.Cryptography;

namespace Learning.AES
{
    public class MyAes
    {
        public void Process2(){ }

        public void Process()
        {
            String secret = "I need to protect it";
            String decodedText = String.Empty;

            byte[] encrypted, key, initializationVector;

            using (Aes aes = Aes.Create())
            {
                Console.WriteLine(secret);

                key = aes.Key;
                initializationVector = aes.IV;

                ICryptoTransform cryptoTransform = aes.CreateEncryptor();

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cryptoStream))
                    {
                        sw.Write(secret);

                    }
                    encrypted = ms.ToArray();
                }
            }

            ShowBytes("Key: ", key);
            ShowBytes("Encrypted: ", encrypted);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = initializationVector;

                ICryptoTransform decoder = aes.CreateDecryptor();

                using (MemoryStream memoryStream = new MemoryStream(encrypted))
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decoder, CryptoStreamMode.Read))
                using (StreamReader streamReader = new StreamReader(cryptoStream))
                {
                    decodedText = streamReader.ReadToEnd();
                }
            }

            Console.WriteLine($"Decoded: {decodedText}");

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
