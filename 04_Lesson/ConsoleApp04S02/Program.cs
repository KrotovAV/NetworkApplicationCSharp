using System.Net.Sockets;
using System.Net;
using System.Text;
using ConsoleApp04S;

namespace ConsoleApp04S02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            
     
            string ip = "127.0.0.1";
            string from = "Kolia";
            Console.WriteLine();
            Console.WriteLine(from);
            Console.WriteLine("--------------");
            UdpClient udpClient = new UdpClient();
           

            Task task = Task.Run(() => client.ClientWork(from, ip));
            task.Wait();
            Console.WriteLine("Kolia Ends");
            //Console.ReadKey();
        }
    }
}