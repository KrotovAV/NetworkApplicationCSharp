using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Prototype
    class Prototype : ICloneable
    {
        public string Name { get; set; }
        public List<String> MoreNames { get; set; } = new List<string>();

        public Prototype(string name)
        {
            Name = name;
        }

        public Prototype Clone1()
        {
            var p = new Prototype(Name);

            p.MoreNames = MoreNames;


            return p;
        }

        public void Print()
        {

            Console.WriteLine("Name=" + Name);
            Console.WriteLine("Names:");
            MoreNames.ForEach(Console.WriteLine);

        }

        public object Clone()
        {
            return this.Clone1();
        }
    }
}
