using System.Net.Sockets;
using System.Text;

namespace ConsoleApp01L05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listener = new TcpListener(System.Net.IPAddress.Any, 12345);

            listener.Start();

            using (TcpClient client = listener.AcceptTcpClient())
            {
                listener.Stop();

                Console.WriteLine($"localEndPoint  = {client.Client.LocalEndPoint}");
                Console.WriteLine($"remoteEndPoint = {client.Client.RemoteEndPoint}");

                while (client.Available == 0) ;
                Console.WriteLine($"Доступно = {client.Available} байт для чтения ");

                using(var stream = client.GetStream())
                {
                    byte[] buffer = new byte[256];
                    int count = stream.Read(buffer, 0, buffer.Length);
                    if(count > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("Сообщение не получено");
                    }
                }
            }
        }
    }
}