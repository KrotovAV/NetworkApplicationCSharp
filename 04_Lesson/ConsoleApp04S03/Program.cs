using System.Net.Sockets;
using System.Net;
using System.Text;
using ConsoleApp04S;

namespace ConsoleApp04S03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            string ip = "127.0.0.2";
            string from = "Dima";
            Console.WriteLine();
            Console.WriteLine(from);
            Console.WriteLine("--------------");


            Task task = Task.Run(() => client.ClientWork(from, ip));
            task.Wait();
            Console.WriteLine("Dima Ends");

        }
    }
}