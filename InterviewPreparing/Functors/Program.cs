using System;
using System.Collections.Generic;

namespace Functors
{
  /*
   * Пространство имен System содержит четыре новых типа делегатов, особенно полезных для манипулирования коллекциями и получения информации из них:

namespace System 
{
  public delegate void Action<T> (T obj);  //dont return parameters.
  public delegate bool Predicate<T> (T obj);  //check some criterias
  public delegate U    Converter<T,U> (T from); //convert one type to other
  public delegate int  Comparison<T> (T x, T y); //Compate two objects of the same types
}
  */


  class Program
  {
    class Article
    {
      public Article(decimal price, string name)
      {
        Price = price;
        Name = name;
      }
      public readonly decimal Price;
      public readonly string Name;
    }

    static bool IsEven(int i) // for ‘Predicate<T>’ 
    {
      return i % 2 == 0;
    }

    private static int lastMax = 0;

    static int sum = 0;

    static void AddToSum(int i)
    {
      sum += i;
    }

    static int CompareArticle(Article x, Article y)
    {
      return Comparer<decimal>.Default.Compare(x.Price, y.Price);
    }

    static decimal ConvertArticle(Article article)
    {
      return (decimal)article.Price;
    }


    static void Main(string[] args)
    {
      List<int> integers = new List<int>();

      for (int i = 1; i <= 10; i++)
        integers.Add(i);

      //integers.Where()
    
      //SortedList<int,int> sl = new SortedList<int, int>();
      
      /*for (int i = 0; i < 5; i++)
      {
        int max = integers.Max(p => p);
        
        Console.WriteLine(max);
        integers.Remove(max);
      }*/

      //IEnumerable<int> ordered = integers.OrderByDescending(p => p, Comparer<int>.Default);
      //foreach (var i in ordered)
      //{
      //  Console.WriteLine(i);
      //}

      /*int[] ar = integers.ToArray();
      Array.Sort(ar);
      Array.Reverse(ar);

      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine(ar[i]);
      }*/
      
      


      // Поиск нечетных чисел.
      // Неявно использует объект делегата ‘Predicate<T>’ 
      List<int> even = integers.FindAll(IsEven);


      // Суммирование элементов списка.
      // Неявно использует объект делегата ‘Action<T>’.
      integers.ForEach(AddToSum);
      Console.WriteLine(sum);
    }
  }
}
