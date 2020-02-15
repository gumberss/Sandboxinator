using System;

namespace Learning.RSA
{
    public class MyRsa
    {
        public void Process()
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
