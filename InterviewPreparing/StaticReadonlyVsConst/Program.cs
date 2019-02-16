using System;

namespace StaticReadonlyVsConst
{
    class MyClass2
    {
        
    }


    class MyClass
    {
        public const MyClass2 mcConst = null;

        public const int x = 10;
        
        private readonly static int y = 30;

        private readonly int notStaticReadonly = 40;

        private readonly string redOnlyString = "red Only String";
        private static readonly string redOnlyStringStatic  = "red Only String Static";

        private string s = "some text";

        private int refInt = 55;

        private MyClass2 mc2 = new MyClass2();

        public MyClass()
        {
            string s = "dsf";
        }

        public MyClass(int x)
        {

        }

        //[method: SomeAttr]
        public void MyMethod()
        {
            string s = "my method string";
            int innerY = 22;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            int b = 10;
            MyClass mc = new MyClass();
            DateTime dt = DateTime.Now;

            for (int i = 0; i < 10000000; i++)
            {
                k = MyClass.x;
            }

            DateTime dt2 = DateTime.Now;
            TimeSpan ts1 = dt2 - dt;

            Console.WriteLine(ts1.TotalMilliseconds);
            
            DateTime dt3 = DateTime.Now;

            for (int i = 0; i < 10000000; i++)
            {
                k = b;
            }

            DateTime dt4 = DateTime.Now;
            TimeSpan ts2 = dt4 - dt3;

            Console.WriteLine(ts2.TotalMilliseconds);




        }
    }
}
