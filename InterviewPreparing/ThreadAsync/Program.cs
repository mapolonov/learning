using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAsync
{
    class Program
    {
        private delegate void del();

        

        static void Main(string[] args)
        {
            Console.WriteLine(" 1 {0}  {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
            //del d = go;
            //d.BeginInvoke(null, null);
            Task t = Task.Run(() =>
            {
                Console.WriteLine(" 1 {0}  {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
            });
            t.Wait();
            //var d = go();
        }

        private static async Task go()
        {
            Console.WriteLine("2 {0}  {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
            await new TaskFactory().StartNew(print);
            Console.WriteLine("3 {0}  {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
        }

        private static void print()
        {
            Console.WriteLine("4 {0}  {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
        }
    }
}
