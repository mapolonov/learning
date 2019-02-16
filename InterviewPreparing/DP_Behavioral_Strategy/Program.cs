using System;

namespace DP_Behavioral_Strategy
{
	// http://www.dofactory.com/Patterns/PatternStrategy.aspx#_self1

	class Program
	{
		static void Main(string[] args)
		{
			Context context;

			// Three contexts following different strategies
			context = new Context(new ConcreteStrategyA());
			context.ContextInterface();

			context = new Context(new ConcreteStrategyB());
			context.ContextInterface();

			context = new Context(new ConcreteStrategyC());
			context.ContextInterface();

			// Wait for user
			Console.ReadKey();
		}
	}

	abstract class Strategy
	{
		public abstract void AlgorithmInterface();
	}

	class ConcreteStrategyA : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine(
			  "Called ConcreteStrategyA.AlgorithmInterface()");
		}
	}

	class ConcreteStrategyB : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine(
			  "Called ConcreteStrategyB.AlgorithmInterface()");
		}
	}

	class ConcreteStrategyC : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine(
			  "Called ConcreteStrategyC.AlgorithmInterface()");
		}
	}

	class Context
	{
		private Strategy _strategy;

		// Constructor
		public Context(Strategy strategy)
		{
			this._strategy = strategy;
		}

		public void ContextInterface()
		{
			_strategy.AlgorithmInterface();
		}
	}
}
