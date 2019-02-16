using System;

namespace DP_Creationals_AbstractFactory
{
  public abstract class AbstractFactory
  {
    public abstract ITextWriter createNewTextWriter();
    public abstract IMultiplicator createNewMultiplicator();
  }

  public abstract class ITextWriter
  {
    public abstract void WriteText();
    
  }

  public abstract class IMultiplicator
  {
    public abstract int Multiply(int x, int y);
  }

  public class TextWriterConcrete : ITextWriter
  {

    public override void WriteText()
    {
      Console.WriteLine("TextWriterConcrete::WriteText");
    }
  }

  public class MultiplicatorConcrete : IMultiplicator
  {
    public override int Multiply(int x, int y)
    {
      Console.WriteLine(x + y);
      return x + y;
    }
  }

  public class FactoryConctere : AbstractFactory
  {

    public override ITextWriter createNewTextWriter()
    {
      return new TextWriterConcrete();
    }

    public override IMultiplicator createNewMultiplicator()
    {
      return new MultiplicatorConcrete();
    }
  }


  class Program
  {
    static void Main(string[] args)
    {
      FactoryConctere fc = new FactoryConctere();

      fc.createNewTextWriter().WriteText();
      fc.createNewMultiplicator().Multiply(10, 20);
    }
  }
}
