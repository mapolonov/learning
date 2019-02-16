using System;

namespace Lambdas
{
  public class MyClass : ICloneable
  {
    public int I { get; set; }

    public MyClass GetCopy()
    {
      return (MyClass)this.MemberwiseClone();
    }

    #region ICloneable Members

    public object Clone()
    {
      return (MyClass)this.MemberwiseClone();
    }

    #endregion
  }

 

  class Test
  {
    delegate bool D();
    delegate bool D2(int i);

    D del;
    D2 del2;
    
    public void TestMethod(int input)
    {
      int j = 0;
      // Initialize the delegates with lambda expressions.
      // Note access to 2 outer variables.
      // del will be invoked within this method.
      del = () =>
      {
        j = 10;
        return j > input;
      };

      // del2 will be invoked after TestMethod goes out of scope.
      del2 = (x) =>
      {
        return x == j;
      };

      // Demonstrate value of j:
      // Output: j = 0 
      // The delegate has not been invoked yet.
      Console.WriteLine("j = {0}", j);        // Invoke the delegate.
      bool boolResult = del();

      // Output: j = 10 b = True
      Console.WriteLine("j = {0}. b = {1}", j, boolResult);
    }

    static void Main(string[] args)
    {
      //http://msdn.microsoft.com/ru-ru/library/bb397687.aspx

      Test test = new Test();
      test.TestMethod(5);

      // Prove that del2 still has a copy of
      // local variable j from TestMethod.
      bool result = test.del2(10);

      // Output: True
      Console.WriteLine(result);

      string d = "asdf";

      int i = 10;
      Console.WriteLine(typeof(Test));

      object obj = 10.2F;

      Console.WriteLine(obj is float);


      MyClass mc = new MyClass{ I = 10 };

      MyClass mcShadow = mc;

      mcShadow.I = 3333;

      Console.WriteLine(mc == mcShadow);
      Console.WriteLine(mc.Equals(mcShadow));
      Console.WriteLine("{0} ::: {1}", mc.I, mcShadow.I);

      MyClass mcDeepCopy = mc.GetCopy();

      Console.WriteLine(mc == mcDeepCopy);
      Console.WriteLine(mc.Equals(mcDeepCopy));

      mcDeepCopy.I = 123;
      Console.WriteLine("{0} ::: {1}", mc.I, mcDeepCopy.I);

      MyClass mcDeepCopy2 = (MyClass)mc.Clone();

      Console.WriteLine(mc == mcDeepCopy2);
      Console.WriteLine(mc.Equals(mcDeepCopy2));

      mcDeepCopy2.I = 777;
      Console.WriteLine("{0} ::: {1}", mc.I, mcDeepCopy2.I);


    }
  }
}
