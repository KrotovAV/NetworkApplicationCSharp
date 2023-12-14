using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp03S
{
    internal class Program
    {
        public static async Task<string> ProcessElementAsync(string elem)
        {
            Random rnd = new Random();
            int delay = rnd.Next(3000, 10000);
            Console.WriteLine(delay);
            await Task.Delay(delay);
            return elem;
        }
        //public static async Task<Task<string>> ReturnMessageFromList()
        //{
        //    List<string> msgs = new List<string>() { "Привет!", 
        //        "Есть время поболтать?", "Как дела?", 
        //        "Что там с сервером?", "Чем занимаешься?", 
        //        "Ну пока!", "Exit" };
        //    List<Task> tasks = new List<Task>();
        //    Task task<string>;
        //    for (int i = 0; i < msgs.Count; i++)
        //    {
        //        //Thread.Sleep(2000);
        //        task = Task.Run(() => ProcessElementAsync(msgs[i]));
        //        task.Wait();
        //        tasks.Add(task);
        //    }
        //    return task;
        //}
        public static async Task<int> TaskArr(int[] array)
        {
            await Task.Delay(1);
            return  array.Sum();
        }

        public static async Task<int> MinPing(string parthName)
        {
            IPAddress[] iPAddreses = Dns.GetHostAddresses(parthName, System.Net.Sockets.AddressFamily.InterNetwork);

            Dictionary<IPAddress, long> pings = new Dictionary<IPAddress, long>();
            for (int i = 0; i < iPAddreses.Length; i++)
            {
                Task task = new Task(() =>
                {
                    Ping p = new Ping();
                    PingReply pingReply = p.Send(iPAddreses[i]);
                    Console.WriteLine($"{iPAddreses[i]} - {pingReply.RoundtripTime}");
                    pings.Add(iPAddreses[i], pingReply.RoundtripTime);
                });
                task.Start();
                await task;
            }

            long? minPing = pings.Min(x => x.Value);
            return (int)minPing;
        }

        public static async Task ProcessMemoryStreamAsync(MemoryStream memoryStream)
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            Console.WriteLine("Start reading from MemoryStream:");

            while ((bytesRead = await memoryStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                // Асинхронная обработка данных
                string dataChunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.Write(dataChunk);
                await Task.Delay(100); // Имитация асинхронной обработки
            }

            Console.WriteLine("Reading from MemoryStream completed.");
        }
        public static async Task<int> ProcessElementAsync(int elem)
        {
            await Task.Delay(1000);
            return elem * 2;
        }
        public static async Task<int[]> ProcessArrayAsync(int[] arr) 
        { 
            return await Task.WhenAll(Array.ConvertAll(arr, async (item) => await ProcessElementAsync(item)));

        }
        public static async Task<int> ProcessSumAsync(int[] arr)
        {
            await Task.Delay(1000);
            return arr.Sum();

        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            /* Задача 1
            Напише приложение для одновременного выполнения двух задач в потоках 
            созданных с помощью Task. Нужно подсчитать сумму элементов каждого из 
            массивов а потом сложить эти суммы полученные после выполнения каждого 
            из потоков и вывести результат на экран.
             */

            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 10, 20, 30, 40, 50 };

            Task<int> t1 = Task.Run(() => TaskArr(arr1));
            Task<int> t2 = Task.Run(() => TaskArr(arr2));

            Task.WaitAll(new Task[] { t1, t2 });
            Console.WriteLine(t1.Result);
            Console.WriteLine(t2.Result);
            Console.WriteLine(t1.Result + t2.Result);

            int s1 = await t1;
            int s2 = await t2;

            Console.WriteLine(s1);
            Console.WriteLine(s2);

            Console.WriteLine(s1 + s2);
            Console.WriteLine("End");

            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            /* Задача 2
            Напишите многопоточное приложение, которое определяет все IP-адреса интернет - ресурса и 
            определяет до которого из них лучше Ping. 
            Приложение должно работать с помощью Task.
            */


            string parthName = "yandex.ru";

            int minPing = await MinPing(parthName);
            Console.WriteLine();
            Console.WriteLine($"minPing - {minPing}");

            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();


            /*  Задача 3
            Добавляем многопоточность в чат позволяя серверной части получать сообщения 
            сразу от нескольких респондентов. Перепишем многопоточность с помощью Task
            */

            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            /* Задача 4
            Реализуйте метод ProcessMemoryStreamAsync таким таким 
            образом чтобы он выводил на экран содержимое потока.
            */

            // Пример использования
            byte[] data = Encoding.UTF8.GetBytes("Hello, this is data for MemoryStream!");

            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                await ProcessMemoryStreamAsync(memoryStream);
            }


            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();


            /* Задача 5
            Напишите пример асинхронной работы с массивом, где сначала будет производится
            изменения элементов массива (например умножение на 2), а затем суммирование 
            и возвращение результата. Реализуйте параллельное выполнение всех операций 
            (включая изменение элементов массива) 
            */

            int[] data5 = { 1, 2, 3, 4, 5 };
            try
            {
                // Асинхронная обработка массива
                Task<int[]> processedDataTask = ProcessArrayAsync(data5);

                // Асинхронный вывод результатов на консоль
                Console.WriteLine("Processed Data:");
                int[] processedData = await processedDataTask;
                foreach (var item in processedData)
                {
                    Console.Write($"{item} ");
                }
                // Асинхронная операция после обработки массива с использованием ContinueWith
                var sumTask = processedDataTask.ContinueWith(t => ProcessSumAsync(t.Result));
                int sum = await await sumTask;
                Console.WriteLine($"Sum of Processed Data: {sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            List<string> msgs = new List<string>() { "Привет!",
                "Есть время поболтать?", "Как дела?",
                "Что там с сервером?", "Чем занимаешься?",
                "Ну пока!", "Exit" };
            string str;
            for (int i = 0; i < msgs.Count; i++)
            {
                //Thread.Sleep(2000);
                Task<string> task = Task.Run(() => ProcessElementAsync(msgs[i]));
                task.Wait();
                Console.WriteLine(i);
                Console.WriteLine(task.Result);
                //str = task.Result;
            }
            //str = Console.ReadLine();
            //Console.WriteLine(str);
        }

    }

}

