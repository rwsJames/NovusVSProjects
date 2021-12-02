using System;
using System.Linq;

namespace ShapeCalculator
{
    class Terminal
    {
        static void Main(string[] args)
        {
            Shape shape;
            string[] acceptedShapeNames = new[] { "circle", "triangle", "square", "rectangle", "sphere", "tetrahedron" };

            while (true)
            {
                Console.Clear();

                string inputShape = "";
                do
                {
                    Console.WriteLine("Repeat the name of a shape: ");
                    foreach (string name in acceptedShapeNames)
                        Console.Write(name + " || ");
                    inputShape = Console.ReadLine().ToLower();
                }
                while (string.IsNullOrWhiteSpace(inputShape) && acceptedShapeNames.Where(n => n.Equals(inputShape)).Any());

                // Determine what further input the user needs to give
                bool invalidShape = false;
                switch (inputShape)
                {
                    case "circle":
                        shape = new Circle(GetLengthsFromUser(1));
                        break;
                    case "triangle":
                        shape = new Triangle(GetLengthsFromUser(3));
                        if (shape.Body() == 0d)
                        {
                            Console.WriteLine("Those lengths cannot make a triangle. Please start again.");
                            invalidShape = true;
                        }
                        break;
                    case "square":
                        shape = new Square(GetLengthsFromUser(1));
                        break;
                    case "rectangle":
                        shape = new Rectangle(GetLengthsFromUser(2));
                        break;
                    case "sphere":
                        shape = new Sphere(GetLengthsFromUser(1));
                        break;
                    case "tetrahedron":
                        shape = new Tetrahedron(GetLengthsFromUser(1));
                        break;
                    default:
                        shape = null;
                        break;
                }

                if (!invalidShape && shape != null)
                    shape.PrintDetails();


                Console.WriteLine("\nPress enter/return to continue...");
                Console.ReadLine();
            }
        }

        static double[] GetLengthsFromUser(int numSides)
        {
            double[] sides = new double[numSides];

            Console.WriteLine("\nYou will enter " + numSides + " length/s:\n");

            for (int i = 0; i < numSides; i++)
            {
                string inputSide = "";
                double side = 0;
                do
                {
                    Console.WriteLine("Number " + i + ": ");
                    inputSide = Console.ReadLine();
                }
                while (!double.TryParse(inputSide, out side) && side > 0);
                sides[i] = side;
            }
            return sides;
        }
    }
}
