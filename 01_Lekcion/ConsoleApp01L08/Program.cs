using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleApp01L08
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (TcpClient client = new TcpClient())
            {
                client.Connect(IPAddress.Parse("127.0.0.1"), 12345);

                using (var writer = new StreamWriter(client.GetStream()))
                {
                    writer.WriteLine("Привет!");
                }
            }
        }
    }
}