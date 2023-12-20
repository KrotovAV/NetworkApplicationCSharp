using System;

namespace ConsoleApp04L
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Singleton");
            Console.WriteLine();

            var x = Singleton.Instance;

            x.DoSomeWork();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Prototype");
            Console.WriteLine();

            Prototype original = new Prototype("Оригинальный объект") { MoreNames = { "Еще одно имя" } };

            Prototype? clone = (Prototype)original.Clone();

            clone?.Print();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Factory");
            Console.WriteLine();

            Creator creatorA = new ConcreteCreatorA();
            Product productA = creatorA.FactoryMethod();

            Creator creatorB = new ConcreteCreatorB();
            Product productB = creatorB.FactoryMethod();

            Console.WriteLine(productA.GetName());
            Console.WriteLine(productB.GetName());

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("AbstractFactory");
            Console.WriteLine();

            bool osWindows = true;

            IControlsFactory factory = null;
            if (osWindows)
            {

                factory = new WindowsControlsFactory();

            }
            else
            {
                factory = new MacOSControlsFactory();

            }

            IButton button = factory.CreateButton();
            ITextBox textBox = factory.CreateTextBox();

            button.Display();
            textBox.Display();


            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Builder");
            Console.WriteLine();

            IBuilder builder = new ConcreteBuilder();


            builder.BuildColor("Синий");

            builder.BuildDescription("Твердый");

            builder.BuildName("Карандаш");



            Product2 product = builder.Build();

            product.ShowInfo();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Adapter");
            Console.WriteLine();

            LegacyLibrary legacyLibrary = new LegacyLibrary();

            ITarget target = new Adapter(legacyLibrary);

            target.Request();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Bridge");
            Console.WriteLine();

            Abstraction abstractionA = new ConcreteAbstractionA(new ConcreteImplementorB());
            Abstraction abstractionB = new ConcreteAbstractionB(new ConcreteImplementorA());

            abstractionA.Operation();
            abstractionB.Operation();


            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Composite");
            Console.WriteLine();

            Composite composite = new Composite();


            IComponent leaf1 = new Leaf();
            composite.Add(leaf1);

            IComponent leaf2 = new Leaf();
            composite.Add(leaf2);

            IComponent component = composite;


            List<IComponent> l = new List<IComponent> { leaf1, leaf2, composite };

            l.ForEach(x => Console.WriteLine(x.Operation()));


            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Decorator");
            Console.WriteLine();

            IComponent2 component2 = new ConcreteComponent();
            IComponent2 decoratorA = new ConcreteDecoratorA(component2);
            IComponent2 decoratorB = new ConcreteDecoratorB(decoratorA);

            decoratorB.Operation();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Facade");
            Console.WriteLine();

            Facade facade = new Facade();
            facade.Operation();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Flyweight");
            Console.WriteLine();


            FlyweightFactory factory2 = new FlyweightFactory();

            IFlyweight flyweight1 = factory2.GetFlyweight("SharedStateA");
            IFlyweight flyweight2 = factory2.GetFlyweight("SharedStateB");
            IFlyweight flyweight3 = factory2.GetFlyweight("SharedStateA");

            flyweight1.Operation("Внешнее состояние 1");
            flyweight2.Operation("Внешнее состояние 2");
            flyweight3.Operation("Внешнее состояние 3");

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Proxy");
            Console.WriteLine();

            Proxy proxy = new Proxy();
            proxy.Request();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Chain Of Responsibility");
            Console.WriteLine();
            Handler handlerA = new ConcreteHandlerA();
            Handler handlerB = new ConcreteHandlerB();
            Handler handlerC = new ConcreteHandlerC();

            handlerA.SetSuccessor(handlerB);
            handlerB.SetSuccessor(handlerC);

            int[] requests = { 5, 15, 25, 99 };

            foreach (int request in requests)
            {
                Console.Write($"Запрос {request}, ");
            }
            Console.WriteLine();
            foreach (int request in requests)
            {
                handlerA.HandleRequest(request);
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Command");
            Console.WriteLine();

            Light light = new Light();
            ICommand lightOnCommand = new LightOnCommand(light);
            ICommand lightOffCommand = new LightOffCommand(light);

            RemoteControl remote = new RemoteControl();

            remote.SetAndExecuteButton(lightOnCommand);

            remote.SetAndExecuteButton(lightOffCommand);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Interpreter");
            Console.WriteLine();

            Expression person = new TerminalExpression("Миша");

            Expression married = new TerminalExpression("женат");
            Expression isMarried = new AndExpression(person, married);

            Console.WriteLine("Миша женат?: " + isMarried.Interpret("Миша женат!"));
            Console.WriteLine("Миша женат?: " + isMarried.Interpret("Миша разведен?"));

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Iterator");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Mediator");
            Console.WriteLine();

            ConcreteMediator mediator = new ConcreteMediator();

            Colleague colleague1 = new ConcreteColleague1(mediator);
            Colleague colleague2 = new ConcreteColleague2(mediator);

            mediator.AddColleague(colleague1);
            mediator.AddColleague(colleague2);

            colleague1.Send("Привет от коллеги 1");
            colleague2.Send("Привет от коллеги 2");

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Memento");
            Console.WriteLine();

            Originator originator = new Originator();
            originator.State = "Состояние 1";

            Caretaker caretaker = new Caretaker();
            caretaker.Memento = originator.CreateMemento();

            originator.State = "Состояние 2";

            Console.WriteLine($"Текущене состояние: {originator.State}");

            originator.RestoreMemento(caretaker.Memento);

            Console.WriteLine($"Востановленное состояние: {originator.State}");

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Observer");
            Console.WriteLine();

            

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("State");
            Console.WriteLine();

            Context context = new Context(new ConcreteStateA());

            context.Request();
            context.Request();
            context.Request();


            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Strategy");
            Console.WriteLine();

            Context2 context2 = new Context2(new ConcreteStrategyA());

            context2.ExecuteStrategy();

            context2.SetStrategy(new ConcreteStrategyB());
            context2.ExecuteStrategy();

            context2.SetStrategy(new ConcreteStrategyC());
            context2.ExecuteStrategy();


            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Template method");
            Console.WriteLine();

            AbstractClass template = new ConcreteClass();
            template.TemplateMethod();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Visitor");
            Console.WriteLine();

            List<IElement> elements = new List<IElement>
            {
                new ConcreteElementA(),
                new ConcreteElementB()
            };

            ConcreteVisitor visitor = new ConcreteVisitor();

            foreach (IElement element in elements)
            {
                element.Accept(visitor);
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }
    }
}