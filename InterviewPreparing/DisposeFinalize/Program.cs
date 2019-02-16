using System;

namespace DisposeFinalize
{
  internal class MyClass : IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
    }
  }
}
