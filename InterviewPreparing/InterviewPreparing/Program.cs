using System;
using System.Linq;
using System.Threading;

namespace InterviewPreparing
{

	public class Singleton
	{
		protected Singleton()
		{
		}

		private sealed class SingletonCreator
		{
			private static readonly Singleton singleInst = new Singleton();

			public static Singleton Instance
			{
				get
				{
					return singleInst;
				}
			}

		}

		public static Singleton GetInstance()
		{
			return SingletonCreator.Instance;
		}
	}


	public class MyClass
	{
		private int x;
		public int X { get { return x; } set { x = value; } }
		public MyClass2 MyClass2 { get; set; }


	}

	public class MyClass2 : IDisposable
	{
		private int y;
		public int Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		~MyClass2()
		{
			Dispose();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}

	// Define an Enum with FlagsAttribute.
	[FlagsAttribute]
	enum MultiHue : short
	{
		Black = 1,
		Red = 2,
		Green = 4,
		Blue = 8
	};

	internal class MyClassEnum
	{
		public MultiHue mh;
	}

	public class X
	{
		protected int a = 10;
		private int b;
		private string s = "asdfasdf";

		public X()
		{
			b = 5;
			Console.WriteLine("X a={0}", a);
			Console.WriteLine("X b={0}", b);
		}

		public X(int b)
		{
			this.b = b;
		}

		protected void methodX()
		{

		}
	}

	public class Y : X
	{
		private int a = 12;
		private int b;

		public Y()
			: base(10)
		{
			b = 15;
			Console.WriteLine("Y a={0}", a);
			Console.WriteLine("Y b={0}", b);
		}

		void meth3()
		{

		}
	}

	class MyGeneric<T>
	{
		public static int X;
		public int Y;
	}

	class DeadLockTest
	{
		public object obj = new object();
		private int lockInt = 10;

		public void run()
		{
			//lock (obj) // good
			//lock(lockInt) // compile error, only reference type!
			Monitor.Enter(lockInt);
			try
			{
				//obj = 1;
				//lockInt = 13;
				Thread.Sleep(3000);
				//Console.WriteLine("work thread: {0}",obj);
				//Console.WriteLine("Runned");
			}
			finally
			{
				Monitor.Exit(lockInt);
			}

		}
	}


	public sealed class MyClass3
	{
		protected MyClass3()
		{

		}

		public static MyClass3 Instance()
		{
			return new MyClass3();
		}
	}



	class Program
	{
		static void Main(string[] args)
		{
		    var s = "mike";
		    var k = new string(s.Reverse().ToArray());
            Console.WriteLine(k);


		    var s2 = "natali";
		    var result = new char[s2.Length];
		    var insIndx = s2.Length - 1;

		    for (int i = 0; i < s2.Length ; i++)
		    {
		        result[insIndx] = s2[i];
		        insIndx--;
		    }
		    Console.WriteLine(result);

		    //Console.WriteLine(typeof(MyClass22).GetFields().First(p=>p.Name == "Red"));
		}
	}

	class MyClass22
	{
		[ConstResourceAttribute("RedRes")]
		public const int Red = 1;
		
		[ConstResourceAttribute("GreenRes")]
		public const int Green = 2;
		
		[ConstResourceAttribute("BlueRes")]
		public const int Blue = 3;
	}

	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
	internal sealed class ConstResourceAttribute : Attribute
	{
		// See the attribute guidelines at 
		//  http://go.microsoft.com/fwlink/?LinkId=85236
		private readonly string positionalString;

		// This is a positional argument
		public ConstResourceAttribute(string positionalString)
		{
			this.positionalString = positionalString;

			// TODO: Implement code here
			//throw new NotImplementedException();
		}

		public string PositionalString { get; private set; }

		// This is a named argument
		public int NamedInt { get; set; }
	}


}
