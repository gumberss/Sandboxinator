using System;

namespace Learning.RSA
{
    public class MyRsa
    {
        public void Process()
        {
            PersonWithCertificate bob = new PersonWithCertificate("Bob");

            PersonWithCertificate marie = new PersonWithCertificate("Marie");

            String marieMessage = "My message that I'm sending to my big friend bob";

            var encryptedMessageBytes = marie.GetSignedMessage(marieMessage);


            var messageIsValid = bob.ValidateMessage(encryptedMessageBytes);

            Console.WriteLine($"Marie's message is valid? {messageIsValid}");

            //var receivedMessage = bob.Decrypt(encryptedMessageBytes.Signature); 

            //Console.WriteLine($"Message sent by Marie: {marieMessage}");

            //Console.WriteLine($"Message received by Bob: {receivedMessage}");
        }

        public void ProcessPersonWithoutCertificate()
        {
            Person bob = new Person("Bob");

            Person marie = new Person("Marie");

            String marieMessage = "My message that I'm sending to my big friend bob";

            var encryptedMessageBytes = marie.Encrypt(marieMessage, bob.PublicKey);

            var receivedMessage = bob.Decrypt(encryptedMessageBytes);

            Console.WriteLine($"Message sent by Marie: {marieMessage}");

            Console.WriteLine($"Message received by Bob: {receivedMessage}");
        }

    }
}
