using System;
using System.Security.Cryptography;
using System.Text;

namespace Learning.RSA
{
    public class Person
    {
        public String Name { get; set; }

        private readonly String _privateKey;
        private RSACryptoServiceProvider _cryptoService;

        public String PublicKey { get; }

        public Person(string name)
        {
            Name = name;

            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = "MyContainer";

            _cryptoService = new RSACryptoServiceProvider(cspParameters);

            _privateKey = _cryptoService.ToXmlString(includePrivateParameters: true);

            PublicKey = _cryptoService.ToXmlString(includePrivateParameters: false);

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

            _cryptoService.FromXmlString(receiverPublicKey);

            var encrypedBytes = _cryptoService.Encrypt(messageBytes, fOAEP: false);

            return encrypedBytes;
        }

        public String Decrypt(byte[] encryptedBytes)
        {
            _cryptoService.FromXmlString(_privateKey);

            var messageBytes = _cryptoService.Decrypt(encryptedBytes, fOAEP: false);

            UTF8Encoding encoding = new UTF8Encoding();

            String originalMessage = encoding.GetString(messageBytes);

            return originalMessage;

        }

    }
}
