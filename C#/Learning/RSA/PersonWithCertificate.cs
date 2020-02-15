using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Learning.RSA
{
    public class PersonWithCertificate
    {
        public String Name { get; set; }

        private readonly String _privateKey;
        private RSACryptoServiceProvider _cryptoService;

        public String PublicKey { get; }

        public PersonWithCertificate(string name)
        {
            Name = name;

            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = "MyContainer";

            var shouldResetKeys = false;

            if (shouldResetKeys)
            {
                var rsaClear = new RSACryptoServiceProvider(cspParameters);
                rsaClear.PersistKeyInCsp = false;
                rsaClear.Clear();
            }

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

        private X509Certificate2 GetCertificate()
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

            store.Open(OpenFlags.ReadOnly);

            var certificate = store.Certificates[0];

            return certificate;
        }

        public Message GetSignedMessage(String message)
        {
            var certificate = GetCertificate();

            byte[] signature = GetSignature(message, certificate);

            return new Message(message, signature);
        }

        private byte[] GetSignature(string message, X509Certificate2 certificate)
        {
            UTF8Encoding encoding = new UTF8Encoding();

            var messageBytes = encoding.GetBytes(message);

            var hash = GetHash(messageBytes);

            var encryptor = certificate.GetRSAPrivateKey();

            var signature = encryptor.SignHash(hash, HashAlgorithmName.SHA1, RSASignaturePadding.Pss);

            return signature;

        }

        private byte[] GetHash(byte[] messageBytes)
        {
            HashAlgorithm hasher = new SHA1Managed();

            var hash = hasher.ComputeHash(messageBytes);

            return hash;
        }
    }

    public class Message
    {
        public Message(string text, byte[] signature )
        {
            Signature = signature;
            Text = text;
        }

        public String Text { get; set; }

        public byte[] Signature { get; set; }
    }
}
