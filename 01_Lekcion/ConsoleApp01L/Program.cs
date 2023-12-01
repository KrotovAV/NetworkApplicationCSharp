using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleApp01L
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var localEndPoint = new IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 12345);

                listener.Blocking = true;

                Console.WriteLine($"listener is bound = {listener.IsBound}");

                listener.Bind(localEndPoint);

                Console.WriteLine($"listener is bound = {listener.IsBound}, port = {(listener.LocalEndPoint as IPEndPoint)?.Port}");

                listener.Listen(100);

                Console.WriteLine($"Waiting for connection, dual mode = {listener.DualMode}");

                List<Socket> socketsRead = new List<Socket>() { listener };
                List<Socket> socketsWrite = new List<Socket>();
                List<Socket> socketsErr = new List<Socket>();

                while (true)
                {
                    socketsRead = new List<Socket>() { listener };
                    socketsWrite = new List<Socket>();
                    socketsErr = new List<Socket>();

                    Socket.Select(socketsRead, socketsWrite, socketsErr, 100);

                    if (socketsRead.Count > 0)
                        break;

                    Console.Write(".");
                    Thread.Sleep(500);
                }


                Socket socket = socketsRead[0].Accept();


                Console.WriteLine("Connected");
                Console.WriteLine("localEndPoint  =" + socket.LocalEndPoint);
                Console.WriteLine("remoteEndPoint =" + socket.RemoteEndPoint);

                byte[] buffer = new byte[255];

                Console.WriteLine("Получаем сообщение");

                int count = socket.Receive(buffer);


                if (count > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer);

                    Console.WriteLine(message + $"(длина {count})");
                }
                else
                {
                    Console.WriteLine("Сообщение не получено!");
                }


            };
        }
    }
}