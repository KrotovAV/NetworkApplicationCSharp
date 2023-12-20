using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    // Memento
    class Memento
    {
        public string State { get; private set; }

        public Memento(string state)
        {
            State = state;
        }
    }

    class Originator
    {
        private string state;

        public string State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine($"Состояние установлено: {state}");
            }
        }

        public Memento CreateMemento()
        {
            return new Memento(state);
        }

        public void RestoreMemento(Memento memento)
        {
            State = memento.State;
        }
    }

    class Caretaker
    {
        public Memento Memento { get; set; }
    }
}
