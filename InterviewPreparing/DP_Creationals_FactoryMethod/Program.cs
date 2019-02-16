using System;
using System.Collections.Generic;

namespace DP_Creationals_FactoryMethod
{
    interface IProduct
    { }

    class Book : IProduct
    {
        public override string ToString()
        {
            return "Its a book";
        }
    }

    class Car : IProduct
    {
        public override string ToString()
        {
            return "Its a car";
        }
    }

    abstract class Creator
    {
        public abstract IProduct FactoryMethod();
    }

    class BookCreator : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new Book();
        }
    }

    class CarCreator : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new Car();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Creator> creators = new List<Creator>();
            creators.Add(new BookCreator());
            creators.Add(new CarCreator());

            foreach (Creator item in creators)
            {
                IProduct prod = item.FactoryMethod();
                Console.WriteLine(prod.ToString());
            }
        }
    }
}
