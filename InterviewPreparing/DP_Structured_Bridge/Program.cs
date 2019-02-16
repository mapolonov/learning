using System;

namespace DP_Structured_Bridge
{
    //В этом случае помогает шаблон bridge, позволяя создавать новые классы, 
    //которые будут реализовывать рисование в различных графических средах. 
    //При использовании такого подхода очень легко можно добавлять как новые фигуры, 
    //так и способы их рисования.

    /** "Implementor" */
    interface IDrawingAPI
    {
        void drawCircle(double x, double y, double radius);
    }

    /** "ConcreteImplementor" 1/2 */
    class DrawingAPI1 : IDrawingAPI 
    {
       public void drawCircle(double x, double y, double radius) {
           Console.WriteLine("API1.circle at {0}:{1} radius {2}\n", x, y, radius);
       }
    }
     
    /** "ConcreteImplementor" 2/2 */
    class DrawingAPI2 : IDrawingAPI 
    {
       public void drawCircle(double x, double y, double radius) { 
            Console.WriteLine("API2.circle at {0}:{1} radius {2}\n", x, y, radius);
       }
    }

    /** "Abstraction" */
    interface IShape
    {
        void draw();                             // low-level
        void resizeByPercentage(double pct);     // high-level
    }

    /** "Refined Abstraction" */
    class CircleShape : IShape 
    {
        private double x, y, radius;
        private IDrawingAPI drawingAPI; // aggregation==composition
        
        public CircleShape(double x, double y, double radius, IDrawingAPI drawingAPI) 
        {
            this.x = x;  this.y = y;  this.radius = radius;
            this.drawingAPI = drawingAPI;
        }

        // high-level i.e. Abstraction specific
        public void resizeByPercentage(double pct)
        {
            radius *= pct;
        }

        // low-level i.e. Implementation specific
        public void draw()
        {
            drawingAPI.drawCircle(x, y, radius);
        }

      
    }

    /** "Refined Abstraction" */
    class SquareShape : IShape
    {
        private double x, y, radius;
        private IDrawingAPI drawingAPI;

        public SquareShape(double x, double y, double radius, IDrawingAPI drawingAPI)
        {
            this.x = x; this.y = y; this.radius = radius;
            this.drawingAPI = drawingAPI;
        }

        // high-level i.e. Abstraction specific
        public void resizeByPercentage(double pct)
        {
            radius = x * y;
        }

        // low-level i.e. Implementation specific
        public void draw()
        {
            drawingAPI.drawCircle(x, y, radius);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            IShape[] shapes = new IShape[] {
            new CircleShape(1, 2, 3, new DrawingAPI1()),
            new CircleShape(5, 7, 11, new DrawingAPI2()),
                };

            foreach (IShape shape in shapes)
            {
                shape.resizeByPercentage(2.5);
                shape.draw();
            }


            //or we can write 


        }
    }
}
