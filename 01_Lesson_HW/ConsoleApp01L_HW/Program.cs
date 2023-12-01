using ConsoleApp01L_HW02;
using System.Net.Sockets;
using System.Net;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp01L_HW
{
    internal class Program
    {
        public static void SendMessage(string From, string ip)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
            while (true)
            {
                string message;
                do
                {
                    //Console.Clear();
                    Console.WriteLine("Введите сообщение для отправки");
                    message = Console.ReadLine();
                } while (string.IsNullOrEmpty(message));

                MyMessage myMessage = new MyMessage() { Text = message, DateTime = DateTime.Now, NickNameFrom = From, NickNameTo = "Server" };
                string jsonMyMessage = myMessage.SerializeMessageToJson();

                byte[]? bytes = Encoding.UTF8.GetBytes(jsonMyMessage);
                udpClient.Send(bytes, bytes.Length, ipEndPoint);
                //-------------------------------------------------
                byte[] bufferIn = udpClient.Receive(ref ipEndPoint);
                if(bufferIn.Length != 0)
                {
                    var sreportStr = Encoding.UTF8.GetString(bufferIn);
                    Console.WriteLine(sreportStr);
                }
                //-------------------------------------------------------
            }
        }
        static void Main(string[] args)
        {

            string ip = "127.0.0.1";
            string from = "Kolia";
            SendMessage(from, ip);
        }
    }
}