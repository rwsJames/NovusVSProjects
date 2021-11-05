using System;

namespace NovusIntro
{
    class Problem10
    {
        public static void Solution()
        {
            Console.WriteLine("Input a starting number: ");
            int input = Int32.Parse(Console.ReadLine());
            for (int i = input + 1; i < input * 2; i++)
                if (IsPrime(i))
                {
                    Console.WriteLine("The next prime is: " + i);
                    break;
                }
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
