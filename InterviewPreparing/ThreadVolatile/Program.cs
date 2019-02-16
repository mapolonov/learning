using System.Threading;
using System.Threading.Tasks;

namespace ThreadVolatile
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new ReorderTest();
            c.Foo();
        }
    }

    class ReorderTest
    {
        private volatile int _a;

        public void Foo()
        {
            var task = new Task(Bar);
            task.Start();
            Thread.Sleep(1000);
            _a = 0;
            task.Wait();
        }

        public void Bar()
        {
            _a = 1;
            while (_a == 1)
            {
            }
        }
    }

}
