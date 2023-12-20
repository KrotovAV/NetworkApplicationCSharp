
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleApp04S
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            /*
            Сделать наш класс полностью клиент-серверным с возможностью отправки данных сразу нескольким клиентам. 
            Доработать код следующим образом:
            - сервер умеет работать как медиатор (умеет отправлять сообщения по имени клиента),
            - умеет возвращать список всех подключенных к нему клиентов. 
            - если сервер получает сообщение с именем получателя, то он отправляет сообщение одному конкретному клиенту.
            - если сервер не получает сообщение без имени получателя, то он отправляет сообщение всем клиентам,

            Для этого доработаем наш класс сообщений добавив поле ToName.
            Имя пользователя сервера всегда будет Server.
            Доработаем систему команд. 
            Если сервер получает команду (как текст сообщения):
                register : то он добавляет клиента в свой список.
                delete: он удаляет клиента из списка

            */
            Server server = new Server();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Console.WriteLine("Нажмите 'Выход' для выключения приложения ");
            Console.WriteLine($"---------------------------------------------\n");
            Console.WriteLine();


            //try
            //{
            Server.MyServer(token);

            if (Console.ReadKey().Key != ConsoleKey.Escape)
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