using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //AbstractFactory
    internal class AbstractFactory
    {
    }
    interface IButton
    {
        void Display();
    }

    interface ITextBox
    {
        void Display();
    }

    class WindowsButton : IButton
    {
        public void Display()
        {
            Console.WriteLine("Отображаем кнопку Windows");
        }
    }

    class WindowsTextBox : ITextBox
    {
        public void Display()
        {
            Console.WriteLine("Отображаем окно ввода Windows");
        }
    }

    class MacOSButton : IButton
    {
        public void Display()
        {
            Console.WriteLine("Отображаем кнопку MacOS");
        }
    }

    class MacOSTextBox : ITextBox
    {
        public void Display()
        {
            Console.WriteLine("Отображаем окно ввода MacOS");
        }
    }

    interface IControlsFactory
    {
        IButton CreateButton();
        ITextBox CreateTextBox();
    }


    class WindowsControlsFactory : IControlsFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ITextBox CreateTextBox() => new WindowsTextBox();
    }

    class MacOSControlsFactory : IControlsFactory
    {
        public IButton CreateButton() => new MacOSButton();
        public ITextBox CreateTextBox() => new MacOSTextBox();
    }

}
