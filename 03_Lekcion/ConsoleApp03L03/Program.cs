namespace ConsoleApp03L03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Parallel.For(0, 50, (x) => { 
                Thread.Sleep(100);
                Console.WriteLine(x);
                }
            );
            Console.WriteLine("--------------------------");
            List<int> list = Enumerable.Range(0, 50).ToList();
            Parallel.ForEach<int>(list, x => { 
                Thread.Sleep(100); 
                Console.WriteLine(x); 
                }
            );

            var parLoopRes = Parallel.ForEach<int>(list, x => {
                Thread.Sleep(100);
                Console.WriteLine(x);
            }
            );


        }
    }
}