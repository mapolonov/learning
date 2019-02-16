using System;
using System.Threading;

namespace AnonimMethods
{
  class Foo<T>
  {
    delegate void DelegateType(T t);

    internal void Fct(T t)
    {
      DelegateType delegateInstance = delegate(T arg)
      {
        System.Console.WriteLine("Hello arg:{0}", arg);
      };
      delegateInstance(t);
    }
  }

  class Program
  {
    private delegate void DelegateType();

    private delegate int DelegateAdd(int x, int y);

    private delegate void DelegateAddGeneric<T>(T t);

    static DelegateType GetMethod()
    {
      return delegate() 
      {
        System.Console.WriteLine("Hello"); //anonim method
      };
    }

    delegate int DelegateTypeCounter();

    static DelegateTypeCounter MakeCounter()
    {
      int counter = 0;
      DelegateTypeCounter delegateInstanceCounter = delegate
                                                    {
                                                      return ++counter;
                                                    };
      return delegateInstanceCounter;
    }


    static void Main(string[] args)
    {
      DelegateType delegateInstance = GetMethod();
      delegateInstance();
      delegateInstance();
      
      Console.WriteLine("\n 1 ***********************************************\n");

      DelegateType delegateInstance2 = delegate()
                                        {
                                          Console.WriteLine("Hello");
                                        };

      delegateInstance2 += delegate // делегат без скобок т.к. нет параметров
                            {
                              Console.WriteLine("Bonjour");
                            }; 

      delegateInstance2();

      Console.WriteLine("\n 2 ***********************************************\n");

      DelegateAdd delegateAdd = delegate(int a, int b)
                                  {
                                    return a + b;
                                  };

      Console.WriteLine(delegateAdd(10, 20));
      Console.WriteLine(delegateAdd(13, 21));

      Console.WriteLine("\n 3 ***********************************************\n");

      Foo<double> inst = new Foo<double>();
      inst.Fct(5.5);

      Console.WriteLine("\n 4 ***********************************************\n");

      DelegateAddGeneric<double> delegateInstance4 = delegate(double arg)
      {
        System.Console.WriteLine("Hello arg:{0}", arg);
      };
      delegateInstance4(5.5);

      DelegateAddGeneric<string> delegateInstance41 = delegate(string arg)
      {
        System.Console.WriteLine("Hello arg:{0}", arg);
      };
      delegateInstance41("DelegateAddGeneric::string");

      Console.WriteLine("\n 5 ***********************************************\n");

      //Анонимные методы особенно подходят для определения “малых” методов, 
      //которые вызываются через делегат. Например, можно воспользоваться 
      //анонимным методом, чтобы закодировать точку входа в поток:

      Thread thread = new Thread(delegate()
      {
        System.Console.WriteLine("ManagedThreadId:{0} Hello",
        Thread.CurrentThread.ManagedThreadId);
      });
      
      thread.Start();

      System.Console.WriteLine("ManagedThreadId:{0} Bonjour",
        Thread.CurrentThread.ManagedThreadId);

      //Другой классический пример подобного использования относится к созданию 
      //(по месту инициализации) обработчиков событий:
      /*
      _button.Click += delegate(object sender, System.EventArgs args) 
      {
        System.Windows.Forms.MessageBox.Show("_button Clicked");
      };
       */

      Console.WriteLine("\n 6 ***********************************************\n");
      //Захват локальных переменных

      DelegateTypeCounter counter1 = MakeCounter();
      DelegateTypeCounter counter2 = MakeCounter();
      System.Console.WriteLine(counter1());
      System.Console.WriteLine(counter1());
      System.Console.WriteLine(counter2());
      System.Console.WriteLine(counter2());

   
    }
  }
}
