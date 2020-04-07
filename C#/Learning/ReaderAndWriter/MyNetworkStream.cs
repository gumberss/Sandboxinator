using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Learning.ReaderAndWriter
{
    public class MyNetworkStream
    {
        public void Process()
        {
            new Thread(Listen).Start();

            Thread.Sleep(1000);

            using (var client = new TcpClient("localhost", 500))
            using (NetworkStream ns = client.GetStream())
            {
                StreamWriter writer = new StreamWriter(ns);

                writer.Write("Hey!");

                writer.Flush();
            }
        }

        public void Listen()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 500);
            listener.Start();

            TcpClient receiverClient = listener.AcceptTcpClient();

            NetworkStream stream = receiverClient.GetStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                String message = reader.ReadToEnd();

                Console.WriteLine(message);
            }
        }
    }
}
