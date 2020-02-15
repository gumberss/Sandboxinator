using System;
using System.Security.Cryptography;
using System.Text;

namespace Learning.RSA
{
    public class Person
    {
        public String Name { get; set; }

        private readonly String _privateKey;

        public String PublicKey { get; }

        public Person(string name)
        {
            Name = name;

            RSACryptoServiceProvider cryptoService = new RSACryptoServiceProvider();

            _privateKey = cryptoService.ToXmlString(includePrivateParameters: true);

            PublicKey = cryptoService.ToXmlString(includePrivateParameters: false);

            Console.WriteLine(Name);
            Console.WriteLine($"Private key: {_privateKey}");
            Console.WriteLine();
            Console.WriteLine($"Public key: {PublicKey}");
            Console.WriteLine();
            Console.WriteLine();
        }

        public byte[] Encrypt(String message, String receiverPublicKey)
        {
            UTF8Encoding encoding = new UTF8Encoding();

            byte[] messageBytes = encoding.GetBytes(message);

            RSACryptoServiceProvider encryptor = new RSACryptoServiceProvider();

            encryptor.FromXmlString(receiverPublicKey);

            var encrypedBytes = encryptor.Encrypt(messageBytes, fOAEP: false);

            return encrypedBytes;
        }

        public String Decrypt(byte[] encryptedBytes)
        {
            RSACryptoServiceProvider decryptor = new RSACryptoServiceProvider();

            decryptor.FromXmlString(_privateKey);

            var messageBytes = decryptor.Decrypt(encryptedBytes, fOAEP: false);

            UTF8Encoding encoding = new UTF8Encoding();

            String originalMessage = encoding.GetString(messageBytes);

            return originalMessage;

        }

    }
}
