using System.Net.Sockets;
using System.Text;

namespace ConsoleApp01L02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {

                Console.WriteLine($"Connecting...");
                try
                {
                    client.Connect(System.Net.IPAddress.Parse("127.0.0.1"), 12345);
                }
                catch
                {
                }

                if (client.Connected)
                {
                    Console.WriteLine("Connected");
                }
                else
                {
                    Console.WriteLine("Connection problem");
                    return;
                }

                byte[] messageBytes = Encoding.UTF8.GetBytes("Привет!");

                client.SendTimeout = 5000;


                if (client.Poll(100, SelectMode.SelectWrite) && !client.Poll(100, SelectMode.SelectError))
                {
                    int count = client.Send(messageBytes);

                    if (count == messageBytes.Length)
                        Console.WriteLine($"Сообщение отправлено ({count} байт)");
                    else
                        Console.WriteLine("Что-то пошло не так");
                }

            };
        }
    }
}