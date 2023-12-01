using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp01L06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using (TcpClient client = new TcpClient())
            {
                var localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);

                Console.WriteLine($"Connecting...");
                try
                {
                    client.Connect(IPAddress.Parse("127.0.0.1"), 12345);
                }
                catch
                {
                }

                if (client.Connected)
                {
                    Console.WriteLine("Connected");
                    Console.WriteLine($"localEndPoint  = {client.Client.LocalEndPoint}");
                    Console.WriteLine($"remoteEndPoint =  {client.Client.RemoteEndPoint}");
                }
                else
                {
                    Console.WriteLine("Connection problem");
                    return;
                }

                using (var stream = client.GetStream())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes("Привет!");
                    try
                    {
                        stream.Write(bytes);
                        Console.WriteLine("Сообщение отправлено");
                    }
                    catch
                    {
                        Console.WriteLine("Сообщение не отправлено");
                    }
                }
                


              

            };
        }
    }
}