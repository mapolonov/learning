using System;

namespace BoxUnbox
{
    interface IInterface
    {
        void add(int i, int j);
    }

    struct MyStruct : IInterface
    {

        public void add(int i, int j = 2)
        {
            Console.WriteLine(  i + j);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IInterface m = new MyStruct(); //boxing
            var m1 = new MyStruct(); // no box, target will be MyStruct, value type
            m1.add(10, j:10);
        }
    }
}
