using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    // Bridge
    
    //Абстракция
    abstract class Abstraction
    {
        protected IImplementor implementor;
        public Abstraction(IImplementor implementor)
        {
            this.implementor = implementor;
        }
        public abstract void Operation();
    }

    //Конкретная абстракция А
    class ConcreteAbstractionA : Abstraction
    {
        public ConcreteAbstractionA(IImplementor implementor) : base(implementor)
        {
        }

        public override void Operation()
        {
            Console.Write("Конкретная абстракция А ");
            implementor.OperationImpl();
        }
    }

    //Конкретная абстракция B
    class ConcreteAbstractionB : Abstraction
    {
        public ConcreteAbstractionB(IImplementor implementor) : base(implementor)
        {
        }

        public override void Operation()
        {
            Console.Write("Конкретная абстракция B ");
            implementor.OperationImpl();
        }
    }

    //Интерфейс реализации
    interface IImplementor
    {
        void OperationImpl();   
    }

    //Конкретная реализация А
    class ConcreteImplementorA : IImplementor
    {
        public void OperationImpl()
        {
            Console.WriteLine("Конкретная реализация А ");
           
        }
    }

    //Конкретная реализация B
    class ConcreteImplementorB : IImplementor
    {
        public void OperationImpl()
        {
            Console.WriteLine("Конкретная реализация B ");

        }
    }
}
