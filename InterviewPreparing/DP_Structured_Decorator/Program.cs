using System;

namespace DP_Structured_Decorator
{
    // The Coffee Interface defines the functionality of Coffee implemented by decorator
    public interface ICoffee
    {
        double getCost(); // returns the cost of the coffee
        String getIngredients(); // returns the ingredients of the coffee
    }

    // implementation of a simple coffee without any extra ingredients
    public class SimpleCoffee : ICoffee
    {
        public double getCost()
        {
            return 1;
        }

        public String getIngredients()
        {
            return "Coffee";
        }
    }

    // abstract decorator class - note that it implements Coffee interface
    abstract public class CoffeeDecorator : ICoffee
    {
        protected ICoffee decoratedCoffee;
        protected String ingredientSeparator = ", ";

        public CoffeeDecorator(ICoffee decoratedCoffee)
        {
            this.decoratedCoffee = decoratedCoffee;
        }

        public virtual double getCost()
        { // implementing methods of the interface
            return decoratedCoffee.getCost();
        }

        public virtual String getIngredients()
        {
            return decoratedCoffee.getIngredients();
        }
    }

    // Decorator Milk that mixes milk with coffee
    // note it extends CoffeeDecorator
    public class Milk : CoffeeDecorator
    {
        public Milk(ICoffee decoratedCoffee) : base(decoratedCoffee) { }

        public override double getCost()
        { // overriding methods defined in the abstract superclass
            return base.getCost() + 0.5;
        }

        public override String getIngredients()
        {
            return base.getIngredients() + ingredientSeparator + "Milk";
        }
    }

    // Decorator Whip that mixes whip with coffee
    // note it extends CoffeeDecorator
    public class Whip : CoffeeDecorator
    {
        public Whip(ICoffee decoratedCoffee)
            : base(decoratedCoffee)
        {
        }

        public override double getCost()
        {
            return base.getCost() + 0.7;
        }

        public override String getIngredients()
        {
            return base.getIngredients() + ingredientSeparator + "Whip";
        }
    }

    // Decorator Sprinkles that mixes sprinkles with coffee
    // note it extends CoffeeDecorator
    public class Sprinkles : CoffeeDecorator
    {
        public Sprinkles(ICoffee decoratedCoffee)
            : base(decoratedCoffee)
        {
        }

        public override double getCost()
        {
            return base.getCost() + 0.2;
        }

        public override String getIngredients()
        {
            return base.getIngredients() + ingredientSeparator + "Sprinkles";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
               ICoffee c = new SimpleCoffee();
        Console.WriteLine("Cost: " + c.getCost() + "; Ingredients: " + c.getIngredients());


        c = new Milk(new Sprinkles(new Whip(c)));
        Console.WriteLine("Cost: " + c.getCost() + "; Ingredients: " + c.getIngredients());

        /* c = new Milk(c);
        Console.WriteLine("Cost: " + c.getCost() + "; Ingredients: " + c.getIngredients());
 
        c = new Sprinkles(c);
        Console.WriteLine("Cost: " + c.getCost() + "; Ingredients: " + c.getIngredients());
 
        c = new Whip(c);
        Console.WriteLine("Cost: " + c.getCost() + "; Ingredients: " + c.getIngredients());
 
        // Note that you can also stack more than one decorator of the same type
        c = new Sprinkles(c);
        Console.WriteLine("Cost: " + c.getCost() + "; Ingredients: " + c.getIngredients());
         */
        }
    }
}
