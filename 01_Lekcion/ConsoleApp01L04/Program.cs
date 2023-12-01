using System.Net.Sockets;
using System.Net;

namespace ConsoleApp01L04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                var localEndPoint = new IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 1234);

                socket.Bind(localEndPoint);

                byte[] buffer = new byte[1];

                int count = 0;
                while (count < 10)
                {
                    EndPoint remoteEndPoint = new IPEndPoint(IPAddress.None, 0);
                    var sf = new SocketFlags();

                    int c = socket.ReceiveMessageFrom(buffer, 0, 1, ref sf, ref remoteEndPoint, out IPPacketInformation info);

                    buffer[0] = (byte)(buffer[0] * 2);
                    socket.SendTo(buffer, remoteEndPoint);


                    count += c;
                }

                Console.WriteLine("\nПрочили 200 байт");

            };
        }
    }
}