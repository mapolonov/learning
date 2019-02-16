using System;
using System.Collections.Generic;

namespace Comparable
{
    class MyClass : IComparable
    {
        private int i;
        private string name;

        public MyClass(int i, string name)
        {
            this.i = i;
            this.name = name;
        }

        public int I
        {
            get { return i; }
        }

        public string Name
        {
            get { return name; }
        }

        public int CompareTo(object obj)
        {
            var c2 = (MyClass)obj;

            if (this.I > c2.I) return 1;
            if (this.I < c2.I) return -1;
            return 0;
        }
    }

    class CustomComparer: IComparer<MyClass>
    {
        public int Compare(MyClass x, MyClass y)
        {
            if (x.I < y.I) return 1;
            if (x.I > y.I) return -1;
            return 0;
        }
    }

    class NameComparer : IComparer<MyClass>
    {
        public int Compare(MyClass x, MyClass y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] {new MyClass(10, "Anna"), new MyClass(3, "Mike"), new MyClass(23, "Hendry"), new MyClass(2, "Robert")};
            Array.Sort(arr, new CustomComparer());

            foreach (var val in arr)
            {
                Console.WriteLine("{0} {1}", val.I, val.Name);
            }

            Console.WriteLine();

            Array.Sort(arr, new NameComparer());

            foreach (var val in arr)
            {
                Console.WriteLine("{0} {1}", val.I, val.Name);
            }
        }
    }
}
