using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Factory

    abstract class Product
    {
        public abstract string GetName();
    }

    class ConcreteProductA : Product
    {
        public override string GetName() => "Concrete Product A";
    }

    class ConcreteProductB : Product
    {
        public override string GetName() => "Concrete Product B";
    }

    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod() => new ConcreteProductA();
    }

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod() => new ConcreteProductB();
    }
}
