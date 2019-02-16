using System;
using System.Threading;

namespace ThreadPool2
{
  class Program
  {
    private static void WorkWithParameter(object s)
    {
      Console.WriteLine(s);
    }


    static void Main(string[] args)
    {
      WaitCallback workItem = new WaitCallback(WorkWithParameter);
      if (!ThreadPool.QueueUserWorkItem(workItem, "ThreadPooled"))
      {
          Console.WriteLine("Could not queue item");
      }

       
    }
  }
}
