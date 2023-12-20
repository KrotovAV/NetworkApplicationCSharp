using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Builder

    class Product2
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Цвет: {Color}");
            Console.WriteLine($"Описание: {Description}");
        }
    }

    interface IBuilder
    {
        void BuildName(string name);
        void BuildColor(string color);
        void BuildDescription(string description);
        Product2 Build();
    }

    class ConcreteBuilder : IBuilder
    {
        private string name;
        private string color;
        private string description;

        public Product2 Build()
        {
            return new Product2 { Name = name, Color = color, Description = description };
        }

        public void BuildName(string name)
        {
            this.name = name;
        }

        public void BuildColor(string color)
        {
            this.color = color;
        }

        public void BuildDescription(string description)
        {
            this.description = description;
        }
    }
}
