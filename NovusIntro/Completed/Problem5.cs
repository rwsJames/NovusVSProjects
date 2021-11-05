using System;

namespace NovusIntro
{
    class Problem5
    {
        // This is the same method as my answer to the question given in the prior assessment
        public static void Solution()
        {
            Console.WriteLine("\nPlease input a string to be reversed: ");
            string input = Console.ReadLine(); ;
            Console.WriteLine("\nInput: " + input);

            Console.Write("\nOutput: ");
            // I'm aware of the string's native Reverse function but was unsure if using it was better,
            /*
            
            IEnumerable<char> reversed = input.Reverse();
            foreach (char c in reversed)
                Console.Write(c);

            */
            // But I did it myself, just in case

            for (int i = input.Length; i >= 1; i--)
            {
                Console.Write(input[i - 1]);
            }
        }
    }
}
