using System;

namespace Generics2
{
  public class Generic<T, U> 
    where T : class, new() 
    where U : struct 
  {
    public T Field1;
    public U Field2;
  }

  class MyClass
  {
    
  }

  class A
  {
    public T MethodA<T>(T arg)
    {
      T temp = arg;
      //...
      return temp;
    }
  }

  class Generic<T>
  {
    T MethodG(T arg)
    {
      T temp = arg;
      //...
      return temp;
    }
  }

  class GenericList<T>
  {
    // CS0693
    public void SampleMethod<T>()
    {
    }
  }

  class GenericList2<T>
  {
    //No warning
    void SampleMethod<U>()
    {
    }
  }

  class Program
  {

    static void Swap<T>(ref T lhs, ref T rhs)
    {
      T temp;
      temp = lhs;
      lhs = rhs;
      rhs = temp;
    }

    public static void TestSwap()
    {
      int a = 1;
      int b = 2;
      
      Swap<int>(ref a, ref b);
      System.Console.WriteLine(a + " " + b);
    }

    static void Main(string[] args)
    {
//      Generic<int> gi = new Generic<int>();

      Generic<MyClass, int> gc = new Generic<MyClass, int>();

      A a = new A();
      Console.WriteLine(a.MethodA((10)));

      GenericList<int> gl = new GenericList<int>();
      
      gl.SampleMethod<int>();




    }
  }
}
