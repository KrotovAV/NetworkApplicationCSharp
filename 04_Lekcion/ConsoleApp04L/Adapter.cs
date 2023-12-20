using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Adapter
    class LegacyLibrary
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Я стар. Но все еще нужен!");
        }
    }

    interface ITarget
    {
        void Request();
    }

    class Adapter : ITarget
    {
        private LegacyLibrary legacyLibrary;

        public Adapter(LegacyLibrary legacyLibrary)
        {
            this.legacyLibrary = legacyLibrary;
        }

        public void Request()
        {
            legacyLibrary.SpecificRequest();
        }
    }

}
