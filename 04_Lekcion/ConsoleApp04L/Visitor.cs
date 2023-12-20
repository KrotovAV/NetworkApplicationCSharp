using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    // Visitor
    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    class ConcreteElementA : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }

        public void OperationA()
        {
            Console.WriteLine("ConcreteElementA Операция A");
        }
    }

    class ConcreteElementB : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }

        public void OperationB()
        {
            Console.WriteLine("ConcreteElementB Операция B");
        }
    }

    interface IVisitor
    {
        void VisitConcreteElementA(ConcreteElementA elementA);
        void VisitConcreteElementB(ConcreteElementB elementB);
    }

    class ConcreteVisitor : IVisitor
    {
        public void VisitConcreteElementA(ConcreteElementA elementA)
        {
            Console.WriteLine("Посетитель посещает ConcreteElementA");
            elementA.OperationA();
        }

        public void VisitConcreteElementB(ConcreteElementB elementB)
        {
            Console.WriteLine("Посетитель посещает ConcreteElementB");
            elementB.OperationB();
        }
    }

}
