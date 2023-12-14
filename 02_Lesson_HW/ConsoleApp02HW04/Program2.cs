using System.Net.Sockets;
using System.Net;
using System.Text;
using ConsoleApp02HW;


namespace ConsoleApp02HW04
{
    internal class Program2
    {
        public static void MyServer2()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Task task = new Task(() =>
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
                            token.ThrowIfCancellationRequested();
                        }
                    }
                }
            }, token);

            try 
            {
                task.Start();
                task.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Сервер завершил работу.");
                    }
                    else
                        Console.WriteLine(e.Message);
                }
            }
        }
        static void Main(string[] args)
        {
            /*
            Добавьте возможность ввести слово Exit в чате клиента, чтобы можно было завершить его работу. 
            В коде сервера добавьте ожидание нажатия клавиши, чтобы также прекратить его работу.

            (т.е. через отправку сообщения Exit от клиента, мы выключаем и клиента, 
            и сервер.)
            */

            Console.WriteLine("--------------");

            MyServer2();

        }
    }
}