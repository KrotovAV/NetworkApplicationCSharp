using System.Net;
using ChatApp;

namespace Client1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World! Client");

            var c = new Client<IPEndPoint>(new UDPMessageSourceClient(), "Вася");
            await c.Start();

            Console.ReadKey(true);
        }
    }
}