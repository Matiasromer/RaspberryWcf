using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryConsole
{
    class Program
    {
            
        private const int Port = 22;
        static void Main(string[] args)
        {
            using (UdpClient socket = new UdpClient(new IPEndPoint(IPAddress.Any, Port)))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                    byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

                    string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
                        remoteEndPoint.Address, remoteEndPoint.Port, message);
                    //Parse(message);
                }
            }
        }
        private static void Parse(string response)
        {
            string[] parts = response.Split(' ');
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
            string LysLine = parts[6];
            string LysStr = LysLine.Substring(LysLine.IndexOf(": ") + 2);
            Console.WriteLine(LysStr);
        }
    }
}
