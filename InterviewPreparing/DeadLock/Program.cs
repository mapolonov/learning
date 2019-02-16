using System;
using System.Threading;

namespace DeadLock
{
  public class Counter
  {
    //public static int Count;

    private int _count;
    private int _evenCount;

    public int Count
    {
      get { return _count; }
      set { _count = value; }
    }

    public int EvenCount
    {
      get { return _evenCount; }
      set { _evenCount = value; }
    }

    public void UpdateCount()
    {
      lock (this)
      {
        _count = _count + 1;
        if (Count % 2 == 0) // An even number
        {
          _evenCount = _evenCount + 1;
        }
      }
    }
  }

  class Deadlocker
  {
    static volatile object ResourceA = new Object();
    static volatile object ResourceB = new Object();

    public void First()
    {
      lock (ResourceA)
      {
        lock (ResourceB)
        {
          Console.WriteLine("First");
        }
      }
    }

    public void Second()
    {
      lock (ResourceB)
      {
        lock (ResourceA)
        {
          Console.WriteLine("Second");
        }
      }
    }
  }


  class Program
  {
    static void UpdateCount(object param)
    {
      Counter count = (Counter)param;

      for (int x = 1; x <= 10000; ++x)
      {
        // Add two to the count
        count.UpdateCount();
      }

    }

    static void Main(string[] args)
    {
      Deadlocker deadlock = new Deadlocker();

      ThreadStart firstStart = new ThreadStart(deadlock.First);
      ThreadStart secondStart = new ThreadStart(deadlock.Second);

      Thread[] threads = new Thread[100];
      Thread[] threads2 = new Thread[100];

      for (int x = 0; x < 100; ++x)
      {
        threads[x] = new Thread(firstStart);
        threads[x].Start();

        threads2[x] = new Thread(secondStart);
        threads2[x].Start();
      }

      for (int x = 0; x < 100; ++x)
      {
        threads[x].Join();
        threads2[x].Join();
      }
      

      /*Counter count = new Counter();

      ParameterizedThreadStart starter = new
          ParameterizedThreadStart(UpdateCount);
      Thread[] threads = new Thread[10];

      for (int x = 0; x < 10; ++x)
      {
        threads[x] = new Thread(starter);
        threads[x].Start(count);
      }

      // Wait for them to complete
      for (int x = 0; x < 10; ++x)
      {
        threads[x].Join();
      }

      // Show to the console the total count and accesses
      Console.WriteLine("Total: {0} - EvenCount: {1}",
          count.Count, count.EvenCount);*/




    }
  }
}
