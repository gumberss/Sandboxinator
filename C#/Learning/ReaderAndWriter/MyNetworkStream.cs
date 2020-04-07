using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Learning.ReaderAndWriter
{
    public class MyNetworkStream
    {
        public void Process()
        {
            using (var client = new TcpClient("localhost", 80))
            using (NetworkStream ns = client.GetStream())
            {
                StreamWriter writer = new StreamWriter(ns);

                writer.Write("Hey!");

                writer.Flush();
            }
        }
    }
}
