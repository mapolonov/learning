using System;
using System.Reflection;

namespace AppDomains
{
  class Program
  {
    static void Main(string[] args)
    {
      AppDomain currentAppDomain = AppDomain.CurrentDomain;

      Assembly[] ass = currentAppDomain.GetAssemblies();

      Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
      Console.WriteLine("Host domain: " + currentAppDomain.FriendlyName);
      Console.WriteLine("domain manager : {0}", currentAppDomain.DomainManager);

      Console.WriteLine("*************** assemblies ***************");
      foreach (var assembly in ass)
      {
        Console.WriteLine(assembly);
      }
      
      AppDomain newDomain = AppDomain.CreateDomain("Mikkas new domain");
      Console.WriteLine("newDomain manager : {0}", newDomain.DomainManager);
      //newDomain.Load("SumpleConApp.exe");

  //    DomainRunner dr = (DomainRunner)newDomain.CreateInstanceFromAndUnwrap(
  //"SumpleConApp.exe", "SumpleConApp.MyClass");
  //    dr.ExecuteAssembly = "SumpleConApp.exe";

      //Worker localWorker = new Worker();
      //localWorker.PrintDomain();

      
      Console.WriteLine(Assembly.GetExecutingAssembly().FullName);
      AppDomain ad = AppDomain.CreateDomain("New domain");
      Worker remoteWorker = (Worker)ad.CreateInstanceAndUnwrap(
           "SumpleConApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
           "SumpleConApp.MyClass");
      remoteWorker.PrintDomain();

    }
  }

  public class Worker : MarshalByRefObject
  {
    public void PrintDomain()
    {
      Console.WriteLine("Object is executing in AppDomain \"{0}\"",
          AppDomain.CurrentDomain.FriendlyName);
    }
  }

  [Serializable]
  public class DomainRunner : MarshalByRefObject
  {
    private string executeAssembly;
    public string ExecuteAssembly
    {
      get
      {
        return executeAssembly;
      }
      set
      {
        executeAssembly = value;
      }
    }

    public void Run()
    {
      //Запускаем приложение
      AppDomain.CurrentDomain.ExecuteAssembly(ExecuteAssembly);
    }
  }
}
