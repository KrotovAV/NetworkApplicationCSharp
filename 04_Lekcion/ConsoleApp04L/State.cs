using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //State
    class Context
    {
        private IState state;

        public Context(IState initialState)
        {
            state = initialState;
        }

        public void SetState(IState newState)
        {
            state = newState;
        }

        public void Request()
        {
            state.Handle(this);
        }
    }

    interface IState
    {
        void Handle(Context context);
    }

    class ConcreteStateA : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("Обрабатываем запрос в состоянии A");
            context.SetState(new ConcreteStateB());
        }
    }

    class ConcreteStateB : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("Обрабатываем запрос в состоянии B");
            context.SetState(new ConcreteStateA());
        }
    }
}
