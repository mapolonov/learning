using System;

namespace StaticClass
{
    static class StaticClass // sealed! 
    {
        //private int x; wrong! only static
        private static int x;
        public static int GetX { get; set; }

        static StaticClass() // ? already private, closed constructor
        {
            x = 10;
            GetX = 20;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(StaticClass.GetX);

        }
    }
}
