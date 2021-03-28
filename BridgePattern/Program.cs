using System;


// Bridge Pattern
namespace BridgePattern
{
    class Program
    {

        // Client
        static void Main(string[] args)
        {
            Shape r1, r2;
            Drawing dp;

            dp = new V1Drawing();
            r1 = new MyRectangle(dp, 1, 1, 2, 2);

            dp = new V2Drawing();
            r2 = new MyCircle(dp, 2, 2, 3);

            r1.draw();
            r2.draw();

        }
    }


    // ## Refined Abstraction
    class MyCircle : Shape
    {
        private double _x;
        private double _y;
        private double _r;


        public MyCircle(Drawing dp, double x, double y, double r) : base(dp)
        {
            base._dp = dp;
            _x = x; _y = y; _r = r;

        }

        // ## Operation
        public override void draw()
        {
            base.drawCircle(_x, _y, _r);
        }
    }


    // ## ConcreImplementorB
    internal class V2Drawing : Drawing
    {
        public override void drawCircle(double x, double y, double r)
        {
            Console.WriteLine($"v2:Drawing a circle({0},{1},{2})", x, y, r);
        }

        public override void drawLine(double x1, object y1, double x2, double y2)
        {
            Console.WriteLine($"v2:Drawing a Line : from ({0},{1}) to ({2},{3})", x1, y1, x2, y2);
        }
    }

    internal class MyRectangle : Shape
    {
        //private Drawing _dp;
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;

        public MyRectangle(Drawing dp, double x1, double y1, double x2, double y2) : base(dp)
        {
            _dp = dp;
            this._x1 = x1;
            this._y1 = y1;
            this._x2 = x2;
            this._y2 = y2;
        }

        public override void draw()
        {
            drawLine(_x1, _y1, _x2, _y1);
            drawLine(_x2, _y1, _x2, _y2);
            drawLine(_x2, _y2, _x1, _y2);
            drawLine(_x1, _y2, _x1, _y1);

        }
    }

    public class V1Drawing : Drawing
    {

        public override void drawCircle(double x, double y, double r)
        {
            Console.WriteLine($"v1:Drawing a circle({0},{1},{2})", x, y, r);
        }

        public override void drawLine(double x1, object y1, double x2, double y2)
        {
            Console.WriteLine($"v1:Drawing a Line : from ({0},{1}) to ({2},{3})", x1, y1, x2, y2);
        }
    }

    // ## Implementor
    public abstract class Drawing
    {

        // ## Operations
        public abstract void drawLine(double x1, object y1, double x2, double y2);
        public abstract void drawCircle(double x, double y, double r);
    }

    // ## Abstraction
    public abstract class Shape
    {


        public abstract void draw();

        public Drawing _dp; // Implementor

        protected Shape(Drawing dp)
        {
            _dp = dp;
        }

        public virtual void drawLine(double x1, double y1, double x2, double y2)
        {
            _dp.drawLine(x1, y1, x2, y2);
        }

        public virtual void drawCircle(double x, double y, double r)
        {
            _dp.drawCircle(x, y, r);
        }
    }
}
