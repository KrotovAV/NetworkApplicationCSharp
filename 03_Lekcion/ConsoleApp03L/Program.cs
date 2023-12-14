using System.Globalization;

namespace ConsoleApp03L
{
    internal class Program
    {
        static void PrintHash()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " - i " + i);
                Thread.Sleep(2000);
            }
        }
        static void PrintText(object obj)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(obj);
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            
            task1.Start();

            Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));

            Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

            Task task4 = new Task(() => PrintHash());

            task1.Wait();   // ожидаем завершения задачи task1
            task2.Wait();   // ожидаем завершения задачи task2
            task3.Wait();   // ожидаем завершения задачи task3

            List<Task> tasks = new List<Task>();
            for(int i = 0; i<10 ; i++)
            {
                tasks.Add(Task.Run(PrintHash));
            }
            Task task5 = new Task(PrintText,"Flip");
            Task task6 = Task.Run(() => PrintText("Flop"));
            task5.Start();
            

            Task.WaitAll(tasks.ToArray());




        }
    }
}