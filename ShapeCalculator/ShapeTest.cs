using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeCalculator
{
    [TestFixture]
    class ShapeTest
    {
        // If the calculated area of the triangle is 0 then the input lengths cannot make a triangle
        // Inputs of 1, 2, 3 for the side lengths are one example of an invalid triangle
        [Test]
        public void InvalidTriangleTest()
        {
            Shape shape = new Triangle(new double[] { 1d, 2d, 3d });

            Assert.AreEqual(0, shape.Body());
        }

        // The traditional method is less stable for small numbers then the alternative used in the program
        // Show that both methods return the same answer
        [Test]
        public void HeronMethodComparison()
        {
            Shape shape = new Triangle(new double[] { 2d, 3d, 4d });
            double halfP = shape.Boundary()/2; // Perimeter of the triangle / 2
            double traditionalResult = Math.Sqrt(halfP * (halfP - shape.dims[0]) * (halfP - shape.dims[1]) * (halfP - shape.dims[2]));

            Assert.AreEqual(shape.Body(), traditionalResult);
        }

        [Test]
        public void CircleTest()
        {
            Shape shape = new Circle(new double[] { 2 });

            // Name assignment is automatic and based on the type of the shape created
            Assert.AreEqual("circle", shape.name);

            // Ensure calculated values are positive and not default of 0
            Assert.Greater(shape.Body(), 0);
            Assert.Greater(shape.Boundary(), 0);

            // r=2 is a special case where the area and perimeter of the circle are equal
            // A nice easy way to see if they are both calculating the same value when they should be
            Assert.AreEqual(shape.Body(), shape.Boundary());

            // Make the shape a unit circle
            shape.dims[0] -= 1;
            // Unit circle's area is equal to pi
            Assert.AreEqual(shape.Body(), Math.PI);
            // Unit circle's perimeter is pi*2 (tau)
            Assert.AreEqual(shape.Boundary(), Math.PI * 2);
        }

        [Test]
        [TestCase(1, ExpectedResult = Math.PI)]
        public double CircleArea(double r)
        {
            return new Circle(new double[] { r }).Body();
        }

        [Test]
        [TestCase(1, ExpectedResult = Math.PI * 2)]
        public double CirclePerimeter(double r)
        {
            return new Circle(new double[] { r }).Boundary();
        }

        [Test]
        public void AADummyTestToGetAccurateTimes()
        {
            Assert.That(0, Is.EqualTo(0));
        }
    }
}
