using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Proxy
    interface ISubject
    {
        void Request();
    }

    class RealClass : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealClass отрабатывает запрос");
        }
    }

    class Proxy : ISubject
    {
        private RealClass realSubject;

        public Proxy()
        {
            realSubject = new RealClass();
        }

        public void Request()
        {
            Console.WriteLine("Proxy получает запрос");
            realSubject.Request();
        }
    }
}
