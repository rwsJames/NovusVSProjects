using System;
using System.Collections.Generic;
using System.Linq;

namespace NovusIntro
{
    class Problem9
    {
        public static void Solution()
        {
            int toFind;
            int max;

            Console.WriteLine("Please input the nth prime you would like to find: ");
            while (!Int32.TryParse(Console.ReadLine(), out toFind))
                Console.WriteLine("Please input the nth prime you would like to find: ");

            Console.WriteLine("Please input the maximum value yoou would like to search to: ");
            while (!Int32.TryParse(Console.ReadLine(), out max))
                Console.WriteLine("Please input the maximum value yoou would like to search to: ");

            List<int> primes = new List<int>();
            for (int i = 2; i <= max; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                    Console.WriteLine(i + " is prime at index " + primes.Count);
                }
                if (primes.Count == toFind)
                {
                    Console.WriteLine("The index " + toFind + " prime is " + primes.Last());
                    break;
                }
            }

            if (primes.Count != toFind)
                Console.WriteLine("No prime found.  Try increasing 'max' or decreasing 'toFind'.");
        }

        static bool IsPrime(int input)
        {
            for (int i = 2; i <= input / 2; i++)
                if (input % i == 0)
                    return false;
            return true;
        }
    }
}
