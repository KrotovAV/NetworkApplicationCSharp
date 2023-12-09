namespace ConsoleApp01L
{
    internal class Program
    {
        static void PrintThread()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - one");
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - two");
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - three");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            for(int i = 0; i < 10; i++)
            {
                //Thread t = new Thread(PrintThread);
                Thread t = new Thread(delegate() { PrintThread(); });
                t.Start();
            }
        }
    }
}