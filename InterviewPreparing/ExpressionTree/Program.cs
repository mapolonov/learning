using System;
using System.Linq.Expressions;

namespace ExpressionTree2
{
  class Program
  {
    static void Main(string[] args)
    {
      Func<int, int, int> add = (a, b) => a + b;
      Func<int, int, int> add2 = delegate(int a, int b) { return a + b;};
      
      //create expression
      Expression<Func<int, int, int>> expr = (a, b) => a + b;
      
      BinaryExpression operation = (BinaryExpression)expr.Body;
      Console.WriteLine(operation);
      Console.WriteLine(expr.Parameters);
    }
  }
}
