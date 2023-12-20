using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    // Strategy
    interface IStrategy
    {
        void Execute();
    }

    class ConcreteStrategyA : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Выполняем статегию A");
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Выполняем статегию B");
        }
    }

    class ConcreteStrategyC : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Выполняем статегию C");
        }
    }


    class Context2
    {
        private IStrategy strategy;

        public Context2(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            strategy.Execute();
        }
    }
}
