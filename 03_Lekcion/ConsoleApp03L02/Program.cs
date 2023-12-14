namespace ConsoleApp03L02
{
    
    internal class Program
    {
        static async Task<int> FirstAsyncMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("AsyncMethod " + i);
                await Task.Delay(300);
            }
            return 42;
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");
            Task<int> task = FirstAsyncMethod();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main " + i);
                Task.Delay(100).Wait();
            }
            int x = await task;
            Console.WriteLine(x);
            Console.WriteLine("End");

        }
    }
}