using System;

namespace NovusIntro
{
    class Problem3
    {
        // This is the same method as my answer to the questions given in the prior assessment
        public static void Solution()
        {
            int padding = 3; // Extra padding added to the left of the triangle
            int numRows; // Number of rows on the triangle

            Console.WriteLine("Please input the height (number of rows) for the triangle: ");
            while (!Int32.TryParse(Console.ReadLine(), out numRows))
                Console.WriteLine("Please input the height (number of rows) for the triangle: ");

            for (int i = 0; i < numRows; i++)
            {
                int numStarsToPrint = 2 * i + 1;
                int maxChars = 2 * (numRows - 1) + 1;
                int numSpaces = padding + (maxChars - numStarsToPrint) / 2;
                string spaces = "";

                for (int j = 0; j < numSpaces; j++)
                    spaces += " ";
                Console.Write(spaces);
                for (int j = 1; j <= numStarsToPrint; j++)
                    Console.Write("*");

                Console.WriteLine();
            }
        }
    }
}
