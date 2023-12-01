using System.Net.Sockets;
using System.Net;

namespace ConsoleApp01L03
{
    internal class Program
    {
        static void Send(byte[] buffer, Socket socket)
        {
            for (int i = 0; i < 5; i++)
            {
                int count = socket.Send(buffer);

                count = socket.Receive(buffer);

                if (count == 1)
                    Console.WriteLine(buffer[0]);
            }
            socket.Close();
        }

        static void Main(string[] args)
        {


            Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Socket socket2 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            var localEndPoint1 = new IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 2234);
            var localEndPoint2 = new IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 2235);


            socket1.Bind(localEndPoint1);
            socket2.Bind(localEndPoint2);

            socket1.Connect("127.0.0.1", 1234);
            socket2.Connect("127.0.0.1", 1234);


            (new Thread(() => Send(new byte[] { 1 }, socket1))).Start();
            (new Thread(() => Send(new byte[] { 2 }, socket2))).Start();
        }
    }
}