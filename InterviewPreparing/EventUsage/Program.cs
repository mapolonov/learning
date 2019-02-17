using System;

namespace EventUsage
{


    public class A
    {
        public void OnDoWork()
        {
            EventHandler _event = null;
            lock (this)
            {
                _event = DoWork;
            }

            if (_event != null)
            {
                foreach (EventHandler handler in _event.GetInvocationList())
                {
                    try
                    {
                        handler(this, new EventArgs());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error in the handler {0}: {1}",
                        handler.Method.Name, e.Message);
                    }
                }
            }

        }

        public event EventHandler DoWork;
    }

    internal class MyClass<Tsdfj>
    {

    }

    public class EventClass
    {
        private int i = 10;

        public event EventHandler MyEvent;

        public void run()
        {
            int a = 20;
            double b = 40.3;

            i = a + 5;
        }

        public int I
        {
            get { return i; }
            set { i = value; }
        }

    }

    class Program
    {
        static void m1(object obj, EventArgs args)
        {
            Console.WriteLine(1);
        }

        static void m2(object obj, EventArgs args)
        {
            Console.WriteLine(2);
        }

        static void m3(object obj, EventArgs args)
        {
            var j = 0;
            var i = 1 / j;
        }

        static void m4(object obj, EventArgs args)
        {
            Console.WriteLine(4);
        }


        static void Main(string[] args)
        {
            //var a = new A(); 
            //a.DoWork += m1;
            //a.DoWork += m2;
            //a.DoWork += m3;
            //a.DoWork += m4;
            //a.OnDoWork();

            Action a1 = () => Console.Write(1);
            Action a2 = () => Console.Write(2);
            Action a3 = () => Console.Write(3);

            var ar1 = (a1 + a2 + a3 + a1 + a2 + a3) - (a1 + a2);
            ar1();
            //((a1 + a2 + a3) - (a1 + a2))();
            //((a1 + a2 + a3) - (a1 + a3))();



            //List<int> intList = new List<int>();
            //List<double> doubleList = new List<double>();
            //List<string> stringList = new List<string>();

            //List<List<string>> stringList2 = new List<List<string>>();

            //EventClass ec = new EventClass();

            //int i = 0;
            //Console.WriteLine(++i);
        }

        static void a_DoWork(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
