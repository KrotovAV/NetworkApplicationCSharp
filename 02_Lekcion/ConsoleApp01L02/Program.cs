namespace ConsoleApp01L02
{
    internal class Program
    {
        [ThreadStatic]
        static int a = 0;
        //static LocalDataStoreSlot localDataStoreSlot = Thread.AllocateDataSlot();
        static void ThreadProc(int x)
        {
            for(int i = 0;i < 10; i++)
            {
                //var data = ((int?)Thread.GetData(localDataStoreSlot))??0;
                //Thread.SetData(localDataStoreSlot, data + x);
                a += x;
                Console.WriteLine("Total " + a);
                Console.WriteLine("proc " + Thread.GetCurrentProcessorId());
            }
            //Console.WriteLine("Total " + (((int?)Thread.GetData(localDataStoreSlot)) ?? 0));
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Thread t1 = new Thread(() => { ThreadProc(1); });
            t1.Start();
            new Thread(() => { ThreadProc(10); }).Start();

            
        }
    }
}