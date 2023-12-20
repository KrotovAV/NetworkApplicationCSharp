using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Flyweight
    interface IFlyweight
    {
        void Operation(string extrinsicState);
    }

    class ConcreteFlyweight : IFlyweight
    {
        private string intrinsicState;

        public ConcreteFlyweight(string intrinsicState)
        {
            this.intrinsicState = intrinsicState;
        }

        public void Operation(string extrinsicState)
        {
            Console.WriteLine($"Приспособленец: Внутреннее состояние = {intrinsicState}, внешнее состояние = {extrinsicState}");
        }
    }

    class FlyweightFactory
    {
        private Dictionary<string, IFlyweight> flyweights = new Dictionary<string, IFlyweight>();

        public IFlyweight GetFlyweight(string key)
        {
            if (!flyweights.ContainsKey(key))
            {
                flyweights[key] = new ConcreteFlyweight(key);
            }
            return flyweights[key];
        }
    }

}
