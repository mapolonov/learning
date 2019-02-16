using System;

namespace DP_Creational_Builder
{
    class Product
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Caption { get; set; }
    }

    abstract class AbstractProductBuilder
    {
        protected Product product;

        public void CreateProduct()
        {
            product = new Product();
        }

        public Product getProduct()
        {
            return product;
        }

        public abstract void buildWidth();
        public abstract void buildHeight();
        public abstract void buildCaption();
    }

    class ConcreteBuilder : AbstractProductBuilder
    {
        public override void buildWidth()
        {
            product.Width = 10;
            Console.WriteLine(product.Width);
        }

        public override void buildHeight()
        {
            product.Height = 20;
            Console.WriteLine(product.Height);
        }

        public override void buildCaption()
        {
            product.Caption = "The builded product from ConcreteBuilder";
            Console.WriteLine(product.Caption);
        }
    }

    class Director
    {
        private AbstractProductBuilder pb;

        public void setProductBuilder(AbstractProductBuilder pb)
        {
            this.pb = pb;
        }

        public Product getProduct()
        {
            return pb.getProduct();
        }

        public void constructProduct()
        {
            pb.CreateProduct();
            pb.buildCaption();
            pb.buildHeight();
            pb.buildWidth();
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(); // например повар

            ConcreteBuilder pb = new ConcreteBuilder(); // например рецепт

            director.setProductBuilder(pb); // даем повару рецепт

            director.constructProduct(); // повар делает продукт по рецепту

            Product pr = director.getProduct(); // забираем готовый продукт и смотрим что получилось

        }
    }
}
