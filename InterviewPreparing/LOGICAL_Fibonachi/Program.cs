using System;
using System.IO;

namespace LOGICAL_Fibonachi
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var m = new Logger())
            {
                m.Write("asdfasdf");
            }

            using (var m = new Logger())
            {
                m.Write("bbbbbb");
            }
        }

        private static void Fibonachi(int lenght)
        {
            if (lenght == 0) { Console.WriteLine("0"); return; }
            if (lenght == 1) { Console.WriteLine("1"); return; }

            long b1 = 0; 
            long b2 = 1;
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            for (int i = 2; i <= lenght; i++)
            {
                long next = b1 + b2;
                b1 = b2;
                b2 = next;
                Console.WriteLine(next);
            }
        }
    }

    class Logger : IDisposable
    {
        private bool disposed = false;
        private TextWriter tw = File.AppendText(@"D:\log.txt");
        private static object lockObject  = new object();

        ~Logger()
        {
            if (!disposed)
            {
                disposed = true;
                Dispose(false);
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                Dispose(true);
            }
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                //clean managed
                tw.Close();
            }
            //clean unmanaged, IntPtr for example: ptr = null;
        }

        public void Clean()
        {
            //clean managed resources but don't call Dispose. Ready for reuse
            Dispose(true);
        }

        public void Write(string message)
        {
            lock (lockObject)
            {
                tw.WriteLine(message);
            }
        }
    }
}
