using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator
{
    abstract class Shape : IShape
    {
        public double[] dims;
        public string name;

        public Shape(string _name, params double[] _dims)
        {
            name = _name;
            dims = _dims;
        }

        public abstract double Body();
        public abstract double Boundary();
        public virtual void PrintDetails()
        {
            Console.Clear();
            Console.WriteLine("If a number comes out as 0.000 then the shape is invalid. \n");

            Console.Write("Shape: " + name + "\nLengths: ");
            foreach (double side in dims)
            {
                Console.Write(side + "   ");
            }
            Console.Write("\n");

            Console.WriteLine("Boundary: {0:f3}", Boundary());
            Console.WriteLine("Body: {0:f3}", Body());
        }
    }

    // 2D
    class Circle : Shape
    {
        public Circle(double[] _radius) : base("circle", _radius)
        { }

        public override double Body()
        {
            return Math.PI * dims[0] * dims[0];
        }

        public override double Boundary()
        {
            return 2 * Math.PI * dims[0];
        }
    }

    class Triangle : Shape
    {
        public Triangle(double[] _sides) : base("triangle", _sides)
        {
            if (_sides.Length != 3)
                throw new IndexOutOfRangeException("Attempt to create " + name + " with " + _sides.Length + " sides.");
        }

        // Heron's Formula (stable): https://en.wikipedia.org/wiki/Heron%27s_formula
        public override double Body()
        {
            double[] orderedDims = dims.OrderByDescending(d => d).ToArray();
            double a = orderedDims[0], b = orderedDims[1], c = orderedDims[2];
            return 0.25d * Math.Sqrt(
                (a + (b + c)) *
                (c - (a - b)) *
                (c + (a - b)) *
                (a + (b - c)));
        }

        public override double Boundary()
        {
            return dims.Sum();
        }
    }

    class Square : Rectangle
    {
        // Optional string must come last so the order must break
        public Square(double[] _side) : base(_side, "square") // <--
        { }
    }

    class Rectangle : Shape
    {
        public Rectangle(double[] _sides, string _name = "rectangle") : base("rectangle", _sides)
        { }

        public override double Body()
        {
            return dims[0] * dims[1];
        }

        public override double Boundary()
        {
            return dims[0] * 2 + dims[1] * 2;
        }
    }

    // 3D
    class Sphere : Shape
    {
        public Sphere(double[] _radius) : base("sphere", _radius)
        { }

        public override double Body()
        {
            return (4d/3d) * Math.PI * dims[0] * dims[0] * dims[0];
        }

        public override double Boundary()
        {
            return 4d * Math.PI * dims[0] * dims[0];
        }
    }

    class Tetrahedron : Shape
    {
        public Tetrahedron(double[] _edge) : base("tetrahedron", _edge)
        { }

        public override double Body()
        {
            return (dims[0] * dims[0] * dims[0])/(6 * Math.Sqrt(2));
        }

        public override double Boundary()
        {
            return Math.Sqrt(3) * dims[0] * dims[0];
        }
    }
}
