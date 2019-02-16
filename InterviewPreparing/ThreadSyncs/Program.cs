using System;
using System.Threading;

namespace ThreadSyncs
{
  class Program
  {
    static void Main(string[] args)
    {

      Semaphore theSemaphore = null;

      try // Try and open the Semaphore
      {
        theSemaphore = Semaphore.OpenExisting("THESEMAPHORE");
      }
      catch (WaitHandleCannotBeOpenedException)
      {
        Console.WriteLine("Not exists THESEMAPHORE");
        // Cannot open the Semaphore because it doesn't exist
      }

      // Create it if it doesn't exist
      if (theSemaphore == null)
      {
        theSemaphore = new Semaphore(0, 10, "THESEMAPHORE");
      }

      //***************************************************************
      //***************************************************************
      //***************************************************************

      Mutex theMutex = null;

      try // Try and open the Mutex
      {
        theMutex = Mutex.OpenExisting("MYMUTEX");
      }
      catch (WaitHandleCannotBeOpenedException)
      {
        Console.WriteLine("Not exists MYMUTEX");
        // Cannot open the mutex because it doesn't exist
      }

      // Create it if it doesn't exist
      if (theMutex == null)
      {
        theMutex = new Mutex(false, "MYMUTEX");
      }

      //***************************************************************
      //***************************************************************
      //***************************************************************

      Mutex oneMutex = null;
      const string MutexName = "RUNMEONLYONCE";

      try // Try and open the Mutex
      {
        oneMutex = Mutex.OpenExisting(MutexName);
      }
      catch (WaitHandleCannotBeOpenedException)
      {
        // Cannot open the mutex because it doesn't exist
      }

      // Create it if it doesn't exist
      if (oneMutex == null)
      {
        oneMutex = new Mutex(true, MutexName);
      }
      else
      {
        // Close the mutex and exit the application
        // because we can only have one instance
        oneMutex.Close();
        return;
      }

      Console.WriteLine("Our Application");
      Console.Read();


      //***************************************************************
      //***************************************************************
      //***************************************************************

      AutoResetEvent autoEvent = new AutoResetEvent(true);
      ManualResetEvent manualEvent = new ManualResetEvent(false);

      autoEvent.Set();
      manualEvent.Reset();

      EventWaitHandle theEvent = null;

      try // Try and open the Event
      {
        theEvent = EventWaitHandle.OpenExisting("THEEVENT");
      }
      catch (WaitHandleCannotBeOpenedException)
      {
        // Cannot open the AutoResetEvent because it doesn't exist
      }

      // Create it if it doesn't exist
      if (theEvent == null)
      {
        theEvent = new EventWaitHandle(false,
            EventResetMode.AutoReset, "THEEVENT");
      }




    }
  }
}
