using System.Net.Sockets;
using System.Net;
using System.Text;
using ConsoleApp03HW;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp03HW05
{
    internal class Program
    {
        public static int Random(int count)
        {
            Random rnd = new Random();
            int res = rnd.Next(0, count);
            return res;
        }
        public static async Task TimerBeforeAutoMessage(int delay)
        {
          
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            int i = 0;

            Task checkReadKey = Task.Run(() =>
            {
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        Console.WriteLine("XXX срабатывание");
                        cancelTokenSource.Cancel();
                        continue;
                        token.ThrowIfCancellationRequested();
                    }
                }
            });

            Task task = Task.Run(() => {
                var cursorTop = Console.CursorTop;
                var cursorLeft = Console.CursorLeft;
                while (delay - i > 0 || !token.IsCancellationRequested)
                {

                    Console.WriteLine($"{delay - i}  {string.Concat(Enumerable.Repeat(". ", delay - i))}");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0, cursorTop);
                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                    i++;
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                    if (Console.KeyAvailable)
                    {
                        Console.WriteLine("срабатывание");
                        token.ThrowIfCancellationRequested();
                        delay = 0;
                    }
                }
            },token);
            await task;
            cancelTokenSource.Dispose();
        }
        public static Task<string> ReadConsoleAsync()
        {
            return Task.Run(() => Console.ReadLine());
        }
        public static async Task<int> RandomAsync(int count)
        {
            Random rnd = new Random();
            int res = rnd.Next(0, count);
            Console.WriteLine($"auto message N - {res}");
            await Task.Delay(1);
            return res;
        }
        public static async Task<string> ReadLineOrAutoMessageAsync(int delay)
        {
            List<string> msgs = new List<string>() { "Привет!", "Есть время поболтать?", "Как дела?",
              "Что там с сервером?", "Чем занимаешься?", "Ну пока!", "Exit" };

            Console.WriteLine("Введите сообщение для отправки");

            Task timer = Task.Run(() => TimerBeforeAutoMessage(delay));

            var read = Task.Run(() =>  ReadConsoleAsync());

            var completedTask = await Task.WhenAny(read, timer);
            if (completedTask == read)
            {
                return read.Result;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Автоматическое сообщение для отправки");
                Thread.Sleep(1000);
                var autoMessage = Task.Run(() => msgs[RandomAsync(msgs.Count).Result]);
                string message = autoMessage.Result;
                Console.WriteLine(message);
                return message;
            }
           
        }
        public static void SendMessage(string From, string ip)
        {
            List<string> msgs = new List<string>() { "Привет!", "Есть время поболтать?", "Как дела?",
              "Что там с сервером?", "Чем занимаешься?", "Ну пока!", "Exit" };

            UdpClient udpClient = new UdpClient();
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

            while (true)
            {
                string message = ReadLineOrAutoMessageAsync(10).Result;
                
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
            string ip = "127.0.0.4";
            string from = "Auto Client 02 + Manual";
            Console.WriteLine();
            Console.WriteLine(from);
            Console.WriteLine("--------------");
            
            SendMessage(from, ip);

            //while (true)
            //{
            //    if (Console.KeyAvailable)
            //    {
            //        Console.WriteLine("СРАБАТЫВАНИЕ");
                    
            //        continue;
            //    }
            //}
        }
    }
}