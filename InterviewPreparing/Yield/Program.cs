using System;
using System.Collections;
using System.Collections.Generic;

namespace Yield
{

  class Program
  {
    //using System.Collections;
    public static IEnumerable Power(int number, int exponent)
    {
      int counter = 0;
      int result = 1;
      while (counter++ < exponent)
      {
        result = result * number;
        yield return result;
      }
    }

    static void Main(string[] args)
    {
       // Display powers of 2 up to the exponent 8:
		//foreach (int i in Power(2, 8))
		//{
		//	Console.Write("{0} ", i);
		//}

		IEnumerable<int> sequence = GetSequence();
		IEnumerator<int> something = sequence.GetEnumerator();

		while (something.MoveNext())
			Console.WriteLine(something.Current);

		Console.ReadKey();


    }

	static IEnumerable<int> GetSequence()
	{
		Random rand = new Random();
		List<int> list = new List<int>();
		for (int i = 0; i < 3; i++)
			list.Add(rand.Next());
		return list;
	}

	static IEnumerable<int> GetSequence2()
	{
		Random rand = new Random();
		for (int i = 0; i < 3; i++)
			yield return rand.Next();
	}
  }
}
