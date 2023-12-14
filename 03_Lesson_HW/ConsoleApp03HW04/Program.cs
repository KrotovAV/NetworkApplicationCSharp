using System.Net.Sockets;
using System.Net;
using System.Text;
using ConsoleApp03HW;

namespace ConsoleApp03HW04
{
    internal class Program
    {
        public static int Random(int count)
        {
            Random rnd = new Random();
            int res = rnd.Next(0, count);
            return res;
        }
        public static async Task<int> RandomAsync(int count)
        {
            Random rnd = new Random();
            int res = rnd.Next(0, count);
            Console.WriteLine($"auto message N - {res}");
            await Task.Delay(1);
            return res;
        }
        public static async Task TimerBeforeAutoMessage(int delay)
        {
            int i = 0;
            Task task = Task.Run(() => {
                var cursorTop = Console.CursorTop;
                var cursorLeft = Console.CursorLeft;
                while (delay - i > 0)
                {
                    Console.WriteLine($"{delay - i}  {string.Concat(Enumerable.Repeat(". ", delay - i))}");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0, cursorTop);
                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                    i++;
                }
                Console.WriteLine();
                Console.WriteLine("Автоматическое сообщение для отправки");
                Thread.Sleep(1000);
            });
            await task;
        }
        public static void SendMessage(string From, string ip)
        {
            List<string> msgs = new List<string>() { "Привет!", "Есть время поболтать?", "Как дела?",
              "Что там с сервером?", "Чем занимаешься?", "Ну пока!", "Exit" };

            UdpClient udpClient = new UdpClient();
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
            while (true)
            {
                Task.Run(async () => await TimerBeforeAutoMessage(Random(msgs.Count)*2)).Wait();
                Task<string> autoMessage = Task.Run(() => msgs[RandomAsync(msgs.Count).Result]);
                string message = autoMessage.Result;
                Console.WriteLine(message);
                Console.WriteLine();
                MyMessage myMessage = new MyMessage() { Text = message, DateTime = DateTime.Now, NickNameFrom = From, NickNameTo = "Server" };
                string jsonMyMessage = myMessage.SerializeMessageToJson();

                byte[]? bytes = Encoding.UTF8.GetBytes(jsonMyMessage);
                udpClient.Send(bytes, bytes.Length, ipEndPoint);

                byte[] bufferIn = udpClient.Receive(ref ipEndPoint);

                if (bufferIn.Length != 0)
                {
                    var reportStr = Encoding.UTF8.GetString(bufferIn);
                    Console.WriteLine(reportStr);
                    if (reportStr.Contains("Exit") || reportStr.Contains("exit"))
                    {
                        Console.WriteLine($"Клиент {From} успешно отключен от сервера");
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {

            string ip = "127.0.0.3";
            string from = "Auto Client 01";
            Console.WriteLine();
            Console.WriteLine(from);
            Console.WriteLine("--------------");

            SendMessage(from, ip);
        }
    }
}