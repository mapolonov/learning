using System;

namespace EqualsTest
{
  internal class MyClassBase
  {

    public override bool Equals(object obj)
    {
      MyClassBase mcb = (MyClassBase) obj;

      if (this.ToString() == mcb.ToString())
      {
        return true;
      }
      else
      {
        return false;
      }

      //return base.Equals(obj);
    }
  }

  internal class MyClass1 : MyClassBase
  {
    public override string ToString()
    {
      return "mc";
    }

  }

  internal class MyClass2 : MyClassBase
  {
    public override string ToString()
    {
      return "mc";
    }
  }

  class Program
  {
    static void Do()
    {

    }

    static void Main(string[] args)
    {
      MyClassBase mc1 = new MyClass1();
      MyClassBase mc2 = new MyClass2();
      MyClassBase mbc = new MyClassBase();

      Console.WriteLine( mc1.Equals(mc2) );
      Console.WriteLine(mc1.Equals(mbc));
      //Console.WriteLine(mc1 == mc2);

    }
  }
}
