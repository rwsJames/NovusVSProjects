using System;

namespace NovusIntro
{
    class Problem7
    {
        public static void Solution()
        {
            Console.WriteLine("\nPlease input a number to sum its digits: ");
            SumTheDigits(Console.ReadLine());
        }

        private static void SumTheDigits(string s)
        {
            int total = 0;
            foreach (char c in s)
                total += Int32.Parse(c.ToString());

            Console.WriteLine(s + "'s digits sum to " + total);
        }
    }
}
