using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Mediator
    abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    class ConcreteMediator : Mediator
    {
        private List<Colleague> colleagues = new List<Colleague>();

        public void AddColleague(Colleague colleague)
        {
            colleagues.Add(colleague);
        }

        public override void Send(string message, Colleague colleague)
        {
            foreach (Colleague col in colleagues)
            {
                if (col != colleague)
                {
                    col.Receive(message);
                }
            }
        }
    }

    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void Send(string message);
        public abstract void Receive(string message);
    }

    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator) { }

        public override void Send(string message)
        {
            mediator.Send(message, this);
        }

        public override void Receive(string message)
        {
            Console.WriteLine("ConcreteColleague1 получил: " + message);
        }
    }

    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator) { }

        public override void Send(string message)
        {
            mediator.Send(message, this);
        }

        public override void Receive(string message)
        {
            Console.WriteLine("ConcreteColleague2 получил: " + message);
        }
    }
}
