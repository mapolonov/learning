using System;

//Задаёт виды создаваемых объектов с помощью экземпляра-прототипа и 
//создаёт новые объекты путём копирования этого прототипа.
//Проще говоря, это паттерн создания объекта через клонирование другого 
//объекта вместо создания через конструктор.

namespace DP_Creationals_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
             // Create two instances and clone each
 
      Prototype p1 = new ConcretePrototype1("I");
      Prototype c1 = p1.Clone();
      Console.WriteLine ("Cloned: {0}", c1.Id);
 
      Prototype p2 = new ConcretePrototype2("II");
      Prototype c2 = p2.Clone();
      Console.WriteLine(object.ReferenceEquals(p2, c2));
      Console.WriteLine ("Cloned: {0}", c2.Id);
 
      // Wait for user
      Console.Read();
        }
    }

    // "Prototype"
    abstract class Prototype
    {
        private string id;

        // Constructor
        public Prototype(string id)
        {
            this.id = id;
        }

        // Property
        public string Id
        {
            get { return id; }
        }

        public abstract Prototype Clone();
    }

    // "ConcretePrototype1"
  class ConcretePrototype1 : Prototype
  {
    // Constructor
    public ConcretePrototype1(string id) : base(id)
    {
    }
 
    public override Prototype Clone()
    {
      // Shallow copy
      return (Prototype)this.MemberwiseClone();
    }
  }
 
  // "ConcretePrototype2"
 
  class ConcretePrototype2 : Prototype
  {
    // Constructor
    public ConcretePrototype2(string id) : base(id)
    {
    }
 
    public override Prototype Clone()
    {
      // Shallow copy
      return (Prototype)this.MemberwiseClone();
    }
  }
 }

