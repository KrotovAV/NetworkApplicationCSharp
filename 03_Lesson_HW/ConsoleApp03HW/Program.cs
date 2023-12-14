using ConsoleApp03HW;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp03HW
{
    internal class Program
    {
        public static void MyServer(CancellationToken token)
        {
            
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Task.Run(() =>
            {
                Console.WriteLine("Сервер ждет сообщение от клиента");
                while (!token.IsCancellationRequested)
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
                            Console.WriteLine("Сервер выключен.");
                            Console.WriteLine();
                            token.ThrowIfCancellationRequested();
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
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Console.WriteLine("Нажмите 'Выход' для выключения приложения ");
            Console.WriteLine();
            Console.WriteLine("--------------");


            //try
            //{
                MyServer(token);
     
                if(Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    cts.Cancel();
                }
            //}
            //catch (AggregateException ae)
            //{
            //    foreach (Exception e in ae.InnerExceptions)
            //    {
            //        if (e is TaskCanceledException)
            //            Console.WriteLine("Операция прервана");
            //        else
            //            Console.WriteLine(e.Message);
            //    }
            //}
            //finally
            //{
                cts.Dispose();
            //}
        }
    }
}