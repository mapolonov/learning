using System;

namespace ExceptionsUsage
{
  internal class MyClass
  {
    public  void run()
    {
      //try
      //{
      A();
      //}
      //catch (Exception ex)
      //{
      //  Console.WriteLine(ex.StackTrace);
      //  Console.WriteLine(ex.Message);
      //}
    }

    public void run2()
    {}

    private  void A()
    {
      try
      {
        B();
      }
      catch
      {
        throw;
      }
      //catch (Exception ex)
      //{
      //  throw (ex);
      //}
    }

    private  void B()
    {
      try
      {
        C();
      }
      catch
      {
        throw;
      }
    }

    private  void C()
    {
      throw new InvalidOperationException();
    }
    
  }

  internal delegate void MyDel();

  class Program
  {
    static void Main(string[] args)
    {
      MyClass mc = new MyClass();

      MyDel md = mc.run;

      //IAsyncResult iar = md.BeginInvoke(null, null);

      //md.EndInvoke(iar);
      //Thread t = new Thread(mc.run);
      //t.Start();

      Action ac = mc.run;
      ac += mc.run2;
      ac += mc.run2;

      foreach (var s in ac.GetInvocationList())
      {
        Console.WriteLine(s.Method);
      }

      //Delegate.Remove(ac, mc.run2);
      ac -= mc.run2;

      foreach (var s in ac.GetInvocationList())
      {
        Console.WriteLine(s.Method);
      }
      
    }
  }
}
