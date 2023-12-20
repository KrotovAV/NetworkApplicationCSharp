using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Composite
    interface IComponent
    {
        int Operation();
    }

    class Leaf : IComponent
    {
        public int Operation()
        {
            return 1;
        }
    }

    class Composite : IComponent
    {
        private List<IComponent> children = new List<IComponent>();

        public void Add(IComponent component)
        {
            children.Add(component);
        }

        public int Operation()
        {
            Console.WriteLine("Операция компоновщика");
            int i = 0;
            foreach (var child in children)
            {
                i += child.Operation();
            }

            return i;
        }
    }
}
