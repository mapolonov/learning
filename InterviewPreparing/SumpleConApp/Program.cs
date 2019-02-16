using System;

namespace SumpleConApp
{
  [Serializable]
  public class MyClass : MarshalByRefObject
  {
    public void GetMessage()
    {
      Console.WriteLine("**********************************");
      Console.WriteLine("Simple Console application");
      Console.WriteLine("**********************************");
    }
  }


  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("**********************************");
      Console.WriteLine("Simple Console application");
      Console.WriteLine("**********************************");
    }
  }
}
