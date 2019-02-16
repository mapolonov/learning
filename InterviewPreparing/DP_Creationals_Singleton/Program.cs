using System;
using System.Threading;

namespace DP_Creationals_Singleton
{
  //variant 1
  public class MySingleton
  {
    private static MySingleton _instance = new MySingleton();

    public static MySingleton Instance
    {
      get
      {
        return _instance;
      }
    }
  }

  //variant 2 recomended by MSDN
   public sealed class Singleton
    {
        protected Singleton() { }

        private sealed class SingletonCreator
        {
            private static readonly Singleton instance = new Singleton();

            public static Singleton Instance 
            { 
                get 
                { 
                    return instance; 
                } 
            }
        }

        public static Singleton Instance
        {
            get
            {
              
              Singleton s = SingletonCreator.Instance;
              
              return s;
            }
        }
    }
    
 
    class Program
    {

        static void CreateSingleton()
        {
          Singleton s = Singleton.Instance;
          Console.Write(s.GetHashCode() + "\t");
        }

        static void CreateMySingleton()
        {
          MySingleton ms = new MySingleton();
          MySingleton s = MySingleton.Instance;
          Console.Write(s.GetHashCode() + "\t");
        }


        static void Main(string[] args)
        {

            Thread[] threads = new Thread[100];
      
            for (int x = 0; x < 100; ++x)
            {
              threads[x] = new Thread(CreateMySingleton);
              threads[x].Start();
            }

          /*
         Object a = new object();
         Object b = new object();
         Console.WriteLine(a.GetHashCode());
         Console.WriteLine(b.GetHashCode());

         
           Singleton s = Singleton.Instance;

           Singleton s2 = Singleton.Instance;

           Console.WriteLine(s==s2);
           Console.WriteLine(object.ReferenceEquals(s,s2));
         */
        }
    }
}
