using System;

namespace Structures
{
  internal abstract class AbstractClass
  {
    public abstract void Go();
  }

  internal interface IInterface
  {
    
  }

  internal class BaseClass
  {
    
  }
  
  internal struct MyStruct : IInterface, IDisposable
  {
    //поля
    public int X; // !!! обязательна инициализация, даже если не юзаем
    public MyClass mc;// = new MyClass(); // Ref тип может быть в поле инициализирован только статический

    public MyStruct(int X)
    {
      this.X = X;
      mc = new MyClass();
    }

    #region IDisposable Members

    public void Dispose()
    {
      Console.WriteLine("Struct Dispose");
    }

    #endregion
  }

  internal struct GenericStruct<T> where T: class
  {
    private T x; 

    public GenericStruct(T x)
    {
      this.x = x;
      
    }
  }

  internal struct LevelOneStruct
  {
    private struct LevelTwoStruct
    {
      
    }
  }

  //!!!! wrongs !!!!!!!!!!!!!!!!!!!!!!!!!!
  //
  //internal static struct StaticStruct
  //internal struct StaticStruct : AbstractClass
  //internal struct StaticStruct : MyClass
  //no default constructor

  internal class MyClass
  {
    //поля
    private int x; // !!! необязательна инициализация если не используем.

    public int Y { get; set; }
    
  }

  class Program
  {
    static void Main(string[] args)
    {
      MyStruct ms1  = new MyStruct(100);
      MyStruct ms2 = ms1;
      //MyStruct msNull = null;

      Console.WriteLine("X = {0}", ms1.X);
      
      MyStruct ms3 =new MyStruct();

      Console.WriteLine("Default constructor: mc is null? = {0}" , ms3.mc == null);

      Console.WriteLine("ms1 equals to ms2: {0}",  ms1.Equals(ms2));
      Console.WriteLine("ms1 reference equals to ms2: {0}", object.ReferenceEquals(ms1, ms2));
      Console.WriteLine("ms1.MyClass reference equals to ms2.MyClass: {0}", object.ReferenceEquals(ms1.mc, ms2.mc));

      ms2.X = 10;
      Console.WriteLine("ms1 equals to ms2: {0}", ms1.Equals(ms2));

      ms1.mc.Y = 10;
      Console.WriteLine(ms1.mc.Y == ms2.mc.Y);



      using(MyStruct mc = new MyStruct())
      {
        
      }

      GenericStruct<MyClass> gs = new GenericStruct<MyClass>(new MyClass());



    }
  }
}
