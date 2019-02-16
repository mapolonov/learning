using System;
using System.Threading;

namespace ThreadsLockVsMonitor
{
  internal class MonitorClass
  {
    public object obj = new object();

    public void Run()
    {
      Object x = obj; // make copy of obj!
      Monitor.Enter(x); // lock on copy of obj
      try
      {
        Thread.Sleep(5000);
      }
      finally
      {
        Monitor.Exit(x);
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {


    }
  }
}
