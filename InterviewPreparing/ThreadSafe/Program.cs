using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadSafe
{
  internal class MyClass
  {
    
  }


  class Program
  {
    static void Hello(object s)
    {
      Console.WriteLine("Hello: " + s);
    }

    static List<string> _list = new List<string>();

    static void Main(string[] args)
    {

     

      WaitCallback workItem = new WaitCallback(Hello);
      if (!ThreadPool.QueueUserWorkItem(workItem, "ThreadPooled"))
      {
          Console.WriteLine("Could not queue item");
      }
      
      int a, b;
      ThreadPool.GetAvailableThreads(out a, out b);

      Console.WriteLine( a + " ::: " + b );


      new Thread(AddItem).Start();
      new Thread(AddItem).Start();

      int i;
      int j;
      ThreadPool.GetMaxThreads(out i, out j);
      Console.WriteLine( i + " ::: " + j );
    }

    static void AddItem()
    {
      lock (_list)
        _list.Add("Item " + _list.Count);

      string[] items;
      lock (_list)
        items = _list.ToArray();
      foreach (string s in items)
        Console.WriteLine(s);
    }

  }
}
