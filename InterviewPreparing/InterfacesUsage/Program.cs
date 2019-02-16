using System;

namespace InterfacesUsage
{
  internal interface IInterface1
  {
    void method1();
    void method2();
  }

  internal interface IInterface2
  {
    void method1();
    void method2();
  }

  class MyClass : IInterface1, IInterface2
  {
    public void methodMy()
    {
    
    }


    #region IInterface1 Members

    void IInterface1.method1()
    {
      Console.WriteLine("IInterface1.method1()");
    }

    void IInterface1.method2()
    {
      Console.WriteLine("IInterface1.method2()");
    }

    #endregion

    #region IInterface2 Members

    void IInterface2.method1()
    {
      (this as IInterface1).method1();
    }

    void IInterface2.method2()
    {
      //IInterface1.method2();
      //methodMy();
      (this as IInterface1).method2();
    }

    #endregion
  }


  class Program
  {
    static void Main(string[] args)
    {
      IInterface2 mc = new MyClass();

      mc.method1();
      mc.method2();


    }
  }
}
