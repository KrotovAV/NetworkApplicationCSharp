using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp04L
{
    //Command
    interface ICommand
    {
        void Execute();
    }

    class LightOnCommand : ICommand
    {
        private Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOn();
        }
    }

    class LightOffCommand : ICommand
    {
        private Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOff();
        }
    }


    class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Свет включен");
        }

        public void TurnOff()
        {
            Console.WriteLine("Свет выключен");
        }
    }

    class RemoteControl
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void ExecuteButton()
        {
            command.Execute();
        }

        public void SetAndExecuteButton(ICommand command)
        {
            this.SetCommand(command);
            this.ExecuteButton();
        }
    }
}
