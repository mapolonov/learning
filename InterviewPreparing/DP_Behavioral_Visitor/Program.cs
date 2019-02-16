using System;


// Проблема: Над каждым объектом некоторой структуры выполняется одна или более операций. 
// Определить новую операцию, не изменяя классы объектов.
// Описывает операцию, которая выполняется над объектами других классов. 
// При изменении Visitor нет необходимости изменять обслуживаемые классы.

namespace DP_Behavioral_Visitor
{
    interface ICarElementVisitor
    {
        void visit(Wheel wheel);
        void visit(Engine engine);
        void visit(Body body);
        void visit(Car car);
    }

    interface ICarElement
    {
        void accept(ICarElementVisitor visitor); // CarElements have to provide accept().
    }

    class Wheel : ICarElement
    {
        private String name;

        public Wheel(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }

        public void accept(ICarElementVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    class Engine : ICarElement
    {
        public void accept(ICarElementVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    class Body : ICarElement
    {
        public void accept(ICarElementVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    class Car : ICarElement
    {
        ICarElement[] elements;

        //ICarElement[]
        public ICarElement[] getElements()
        {
            return (ICarElement[])elements.Clone(); // Return a copy of the array of references.
        }

        public Car()
        {
            this.elements = new ICarElement[]
          { new Wheel("front left"), new Wheel("front right"),
            new Wheel("back left") , new Wheel("back right"),
            new Body(), new Engine() };
        }

        public void accept(ICarElementVisitor visitor)
        {
            foreach (ICarElement element in this.getElements())
            {
                element.accept(visitor);
            }

            visitor.visit(this);
        }
    }

    class CarElementPrintVisitor : ICarElementVisitor
    {
        public void visit(Wheel wheel)
        {
            Console.WriteLine("Visiting " + wheel.getName() + " wheel");
        }

        public void visit(Engine engine)
        {
            Console.WriteLine("Visiting engine");
        }

        public void visit(Body body)
        {
            Console.WriteLine("Visiting body");
        }

        public void visit(Car car)
        {
            Console.WriteLine("Visiting car");
        }
    }

    class CarElementDoVisitor : ICarElementVisitor
    {
        public void visit(Wheel wheel)
        {
            Console.WriteLine("Kicking my " + wheel.getName() + " wheel");
        }

        public void visit(Engine engine)
        {
            Console.WriteLine("Starting my engine");
        }

        public void visit(Body body)
        {
            Console.WriteLine("Moving my body");
        }

        public void visit(Car car)
        {
            Console.WriteLine("Starting my car");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.accept(new CarElementPrintVisitor());
            car.accept(new CarElementDoVisitor());
        }
    }
}
