using System;

namespace OperatorOverloading
{
  internal class OperatorsClass
  {
    public string FirstName { get; set; }
    public string SecondName { get; set; }

    public OperatorsClass(string fn,  string sn)
    {
      FirstName = fn;
      SecondName = sn;
    }

    public static OperatorsClass operator +(OperatorsClass c1, OperatorsClass c2)
    {
      return new OperatorsClass(c1.FirstName + c2.FirstName, c1.SecondName + c2.SecondName);
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      OperatorsClass oc1 = new OperatorsClass("Mikki", "Apolonov");
      OperatorsClass oc2 = new OperatorsClass("George", "Sidorov");

      OperatorsClass oc3 = oc1 + oc2;

      Console.WriteLine(oc3.FirstName + " : " + oc3.SecondName  );
    }
  }
}
