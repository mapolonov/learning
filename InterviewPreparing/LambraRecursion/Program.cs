using System;
using System.Numerics;

namespace LambraRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = 5;
            Func<int, BigInteger> fact = null;
            fact = x => x > 1 ? x * fact(x - 1) : 1;

            v = 10;
            Console.WriteLine(fact(v));
            Console.WriteLine(fact(v));

            var fact2 = YPointCombinator.Create<int, BigInteger>(f => (n) => n > 1 ? n * f(n - 1) : 1);
            var power = YPointCombinator.Create<int, int, BigInteger>(f => (x, y) => y > 0 ? x * f(x, y - 1) : 1);

            Console.WriteLine(fact2(5));

            int counter = 1;
            //Count(() => { counter++; return counter; });
            //var ff = YPointCombinator.Create<int>(() => 
            //{
                
            //    for (int i = 0; i < 10; ++i)
            //        Console.WriteLine("{0}, ", f());
            //});
            ////Console.WriteLine("cnt {0}", counter.ToString()); 
        }

        static void Count(Func<int> counter)
        {
            for (int i = 0; i < 10; ++i)
                Console.WriteLine("{0}, ", counter());
        } 

        

    }

    //Решает проблему захвата переменной лямбда функцией
    //http://habrahabr.ru/post/113586/
    //https://ru.wikipedia.org/wiki/%D0%9A%D0%BE%D0%BC%D0%B1%D0%B8%D0%BD%D0%B0%D1%82%D0%BE%D1%80_%D0%BD%D0%B5%D0%BF%D0%BE%D0%B4%D0%B2%D0%B8%D0%B6%D0%BD%D0%BE%D0%B9_%D1%82%D0%BE%D1%87%D0%BA%D0%B8
    public static class YPointCombinator
    {
        //public static Action<T1> Create<T1>(Action<Action<T1>> f)
        //{
        //    return f(r=> Create()
        //        );
        //}
        public static Func<T1, T2> Create<T1, T2>(Func<Func<T1, T2>, Func<T1, T2>> f)
        {
            return f(r => Create(f)(r));
        }
        public static Func<T1, T2, T3> Create<T1, T2, T3>(Func<Func<T1, T2, T3>, Func<T1, T2, T3>> f)
        {
            return f((r1, r2) => Create(f)(r1, r2));
        }
    }
}
