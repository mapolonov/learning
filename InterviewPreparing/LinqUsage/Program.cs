using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqUsage
{
  internal class Customer
  {
    public string CustomerId { get; set; }
    public string City { get; set; }

    public override string ToString()
    {
      return CustomerId + "\t" + City;
    }
  }

  class Program
  {
    static IEnumerable<Customer> CreateCustomers()
    {
      return new List<Customer>
               {
                 new Customer {CustomerId = "1", City = "Kiev"},
                 new Customer {CustomerId = "2", City = "Obukhov"},
                 new Customer {CustomerId = "3", City = "Kirovograd"},
                 new Customer {CustomerId = "4", City = "Minsk"},
                 new Customer {CustomerId = "5", City = "Vinnitsa"},
                 new Customer {CustomerId = "6", City = "Kerch"},
                 new Customer {CustomerId = "7", City = "Moscow"}
               };
  }

    static void Main(string[] args)
    {
      var numbers = new int[] {1,2,3,4,5,6,7,8,9};

      var evennumbers = from n in numbers
                        where n%2 == 0
                        select n;

      foreach (var i in evennumbers)
      {
        Console.WriteLine(i);
      }

      Console.WriteLine("\n**************************************\n");

      //var 
      //IEnumerable
      var result = from c in CreateCustomers()
                                     where c.City.StartsWith("K")
                                     group c by c.City;
                   //select c;

      foreach (var customer in result)
      {
        Console.WriteLine(customer);
      }
      


    }
  }
}
