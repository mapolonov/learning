using System;
using System.Threading;

namespace Semaphore2
{
  class Program
  {
    // A semaphore that simulates a limited resource pool.
    private static Semaphore ResourceLock;

    public static void Main()
    {
      // Create a semaphore that can satisfy up to two
      // concurrent requests. Use an initial count of zero,
      // so that the entire semaphore count is initially
      // owned by the main program thread.
      //
      ResourceLock = new Semaphore(0, 2);

      // Create and start threads and assign them a name
      for (int Lp = 1; Lp <= 5; Lp++)
      {
        Thread workThread = new Thread(new ThreadStart(Worker));

        // Start the thread, but name it first
        workThread.Name = Lp.ToString();
        workThread.Start();
      }

      // By releasing 2 here we make 2 slots available for other tasks to start processing
      Console.WriteLine("Main Releases 2.");
      Thread.Sleep(6000);
      ResourceLock.Release(1);

      Console.WriteLine("Main exits.");
    }

    private static void NonCriticalSection(string Id)
    {
      Console.WriteLine("Thread {0} enters the non-critical section", Id);
    }

    private static void CriticalSection(string Id)
    {
      Console.WriteLine("Thread {0} enters the critical section", Id);
    }

    private static void Worker()
    {
      // Obtain the thread name
      string Name = Thread.CurrentThread.Name;
      Console.WriteLine("Thread {0} has started", Name);

      for (int Lp = 0; Lp < 2; Lp++)
      {
        // This funtion is not critical -- anyone can enter
        NonCriticalSection(Name);

        // We need to aquire access to be able to enter the critical section
        ResourceLock.WaitOne();

        CriticalSection(Name);

        // We need to think about this for a bit -- some algortihm
        Thread.Sleep(500);

        // We have finished our job, so release the semaphore
        int prevCount = ResourceLock.Release();

        // Report on how many places are available
        Console.WriteLine("Thread {0} released the semaphore, previously there were {1} slots open.",
            Name,   // {0}
            prevCount); // {1}
      }

      Console.WriteLine("Thread {0} has finished", Name);

    }
  }
}
