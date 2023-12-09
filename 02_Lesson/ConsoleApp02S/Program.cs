using System.Net;
using System.Net.NetworkInformation;

namespace ConsoleApp02S
{
    internal class Program
    {
         
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /*
            Напише приложение для одновременного выполнения двух задач в потоках. 
            Нужно подсчитать сумму элементов каждого из массивов,
            а потом сложить эти суммы полученные после выполнения каждого из потоков 
            и вывести результат на экран.
            */
            int res1 = 0;
            int res2 = 0;
            int[] _array1 = new int[] { 1, 2, 3, 4, 5 };
            int[] _array2 = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            Thread thread1 = new Thread(() => res1 = _array1.Sum());
            Thread thread2 = new Thread(() => res2 = _array2.Sum());

            thread1.Start();
            thread2.Start();

            thread1.Join(1000);
            thread2.Join(1000);
            Console.WriteLine($"{res1} + {res2} = {res1 + res2}");

            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            /*
            Габиль Асланов Напишите многопоточное приложение, которое определяет все IP-адреса 
            интернет-ресурса и определяет до которого из них лучше Ping. 
            */
            const string parthName = "yandex.ru";

            IPAddress[] iPAddreses = Dns.GetHostAddresses(parthName, System.Net.Sockets.AddressFamily.InterNetwork);

            Dictionary<IPAddress, long> pings = new Dictionary<IPAddress, long>();
            List<Thread> threads = new List<Thread>();

            foreach(var iPAddres in iPAddreses)
            {
                Thread? thread = new Thread(() =>
                {
                    Ping p = new Ping();
                    PingReply pingReply = p.Send(iPAddres);
                    pings.Add(iPAddres, pingReply.RoundtripTime);
                });
                threads.Add(thread);
                thread.Start();
            }


            foreach (var thread in threads)
            {
                thread.Join();
            }

            foreach (var ping in pings)
            {
                Console.WriteLine($"{ping.Key}. ping - {ping.Value}");
            }

            long minPing = pings.Min(x => x.Value);

            Console.WriteLine($"minPing - {minPing}");


            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            /*
            Добавляем многопоточность в чат позволяя серверной части получать 
            сообщения сразу от нескольких респондентов. 
            Временно удалим из сервера возможность ввода сообщений. 
            Сделаем так чтобы чат всегда отвечал “Сообщение получено”. 
            Протестируем наш чат запустив сразу 10 клиентов. 
            Для удобства сделаем так чтобы клиент также ничего не запускал но просто слал привет.
            */




            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

        }
    }
}