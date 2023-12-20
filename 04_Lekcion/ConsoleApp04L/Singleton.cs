using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Singleton 
    internal class Singleton
    {
        //public static readonly Lazy<Singleton> lazeInstanse = new Lazy<Singleton>(() => new Singleton());
        //public static Singleton Instance => lazeInstanse.Value;
        // Это то же самое что и снизу только в совеременной обвертке Lazy дл ясоздания синглотонов

        public static Singleton instance;


        public static readonly object lockObj = new object();
        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if(instance == null)
                {
                    lock(lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
        public void DoSomeWork() => Console.WriteLine("Work");
    }
}
