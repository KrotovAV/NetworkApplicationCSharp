using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Facade
    class Subsystem1
    {
        public void Operation1()
        {
            Console.WriteLine("Операция подсистемы 1");
        }
    }

    class Subsystem2
    {
        public void Operation2()
        {
            Console.WriteLine("Операция подсистемы 2");
        }
    }

    class Subsystem3
    {
        public void Operation3()
        {
            Console.WriteLine("Операция подсистемы 3");
        }
    }


    class Facade
    {
        private Subsystem1 subsystem1;
        private Subsystem2 subsystem2;
        private Subsystem3 subsystem3;

        public Facade()
        {
            subsystem1 = new Subsystem1();
            subsystem2 = new Subsystem2();
            subsystem3 = new Subsystem3();
        }

        public void Operation()
        {
            Console.WriteLine("Операция фасада");
            subsystem1.Operation1();
            subsystem2.Operation2();
            subsystem3.Operation3();
        }
    }

}
