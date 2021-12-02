using System;

namespace NovusIntro
{
    class Problem4
    {
        // This is the same method as my answer to the question given in the prior assessment
        public static void Solution()
        {
            int padding = 3; // Extra padding added to the left of the triangle
            int numRows; // Number of rows to the middle of the diamond 
                         // (e.g. 5 would mean 4 rows either side of the middle 5th row, to total 9 rows)

            Console.WriteLine("Please input the number of rows to the centre of the diamond: ");
            while (!Int32.TryParse(Console.ReadLine(), out numRows))
                Console.WriteLine("Please input the number of rows to the centre of the diamond: ");

            for (int i = 0; i < numRows; i++)
            {
                int numStarsToPrint = 2 * i + 1;
                int maxChars = 2 * (numRows - 1) + 1;
                int numSpaces = padding + (maxChars - numStarsToPrint) / 2;

                PrintSpaces(numSpaces);
                PrintStars(numStarsToPrint);
            }

            // -1 for the line from using 0-based 
            // -1 for the line that has already been printed
            for (int i = numRows - 2; i >= 0; i--)
            {
                int numStarsToPrint = 2 * i + 1;
                int maxChars = 2 * (numRows - 1) + 1;
                int numSpaces = padding + (maxChars - numStarsToPrint) / 2;

                PrintSpaces(numSpaces);
                PrintStars(numStarsToPrint);
            }
        }

        private static void PrintStars(int n)
        {
            for (int j = 1; j <= n; j++)
                Console.Write("*");
            Console.WriteLine();
        }

        private static void PrintSpaces(int n)
        {
            string spaces = "";
            for (int j = 0; j < n; j++)
                spaces += " ";
            Console.Write(spaces);
        }
    }
}
