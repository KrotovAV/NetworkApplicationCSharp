using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Decorator
    interface IComponent2
    {
        void Operation();
    }

    class ConcreteComponent : IComponent2
    {
        public void Operation()
        {
            Console.WriteLine("Метод компонента вызван");
        }
    }

    abstract class Decorator : IComponent2
    {
        protected IComponent2 component;

        public Decorator(IComponent2 component)
        {
            this.component = component;
        }

        public virtual void Operation()
        {
            component.Operation();
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent2 component) : base(component)
        {
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Метод декоратора A вызван");
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent2 component) : base(component)
        {
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Метод декоратора B вызван");
        }
    }
}
