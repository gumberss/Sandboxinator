using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Learning.AES
{
    public class MyRijndael
    {
        public void Process()
        {
            String secret = "I need to protect it";
            String decodedText = String.Empty;

            byte[] encrypted, key, initializationVector;

            using (Rijndael rijndael = Rijndael.Create())
            {
                Console.WriteLine(secret);

                key = rijndael.Key;
                initializationVector = rijndael.IV;

                ICryptoTransform cryptoTransform = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

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

            using (Rijndael rijndael = Rijndael.Create())
            {
                ICryptoTransform decoder = rijndael.CreateDecryptor(key, initializationVector);

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
