using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConsoleApp02HW
{
    internal class Program
    {
        public static void MyServer()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            ThreadPool.QueueUserWorkItem((obj) =>
            {
                Console.WriteLine("Сервер ждет сообщение от клиента");
                while (!cts.IsCancellationRequested)
                {
                    byte[] buffer = udpClient.Receive(ref iPEndPoint);
                    if (buffer == null) break;
                    string messageText = Encoding.UTF8.GetString(buffer);

                    MyMessage? message = MyMessage.DeserializeMessageFromJson(messageText);
                    message?.PrintMessageFrom();

                    if (message != null)
                    {
                        byte[] bufferOut = Encoding.UTF8.GetBytes($"*** Сообщение - {message.Text} - получено сервером {message.DateTime}.\n ");
                        udpClient.Send(bufferOut, bufferOut.Length, iPEndPoint);
                        if (message.Text.Contains("Exit") || message.Text.Contains("exit"))
                        {
                            Console.WriteLine($"Клиент {message.NickNameFrom} будет выключен.");
                            cts.Cancel();
                            Console.WriteLine("Сервер выключен.");
                            Console.WriteLine();
                            Console.WriteLine("Для выключения приложения нажмите любую клавишу.");
                        }
                    }
                }
            }, token);
            
        }
        static void Main(string[] args)
        {
            /*
            Добавьте возможность ввести слово Exit в чате клиента, чтобы можно было завершить его работу. 
            В коде сервера добавьте ожидание нажатия клавиши, чтобы также прекратить его работу.

            (т.е. через отправку сообщения Exit от клиента, мы выключаем и клиента, 
            и останавливаем пул потоков сервер. Для завершения работы приложения нажимаем любую клавишу)
            */

            Console.WriteLine("Для выключения приложения нажмите любую клавишу");
            Console.WriteLine();
            Console.WriteLine("--------------");

            MyServer();

            Console.ReadKey();
            
        }
    }
}