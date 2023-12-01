using System.Net.Sockets;
using System.Text;

namespace ConsoleApp01L07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listener = new TcpListener(System.Net.IPAddress.Any, 12345);

            listener.Start();

            using (TcpClient client = listener.AcceptTcpClient())
            {

                Console.WriteLine("Conected");

                using (var reader = new StreamReader(client.GetStream()))
                {
                    Console.WriteLine(reader.ReadLine());
                }

            }
        }
    }
}