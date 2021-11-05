using System;

namespace NovusIntro
{
    class Problem6
    {
        public static void Solution()
        {
            PrintIfIsPalindrome("madam");
            PrintIfIsPalindrome("step on no pets");
            PrintIfIsPalindrome("book");

            Console.WriteLine("\nPlease input a sequence of characters to see if it is a palindrome: ");
            PrintIfIsPalindrome(Console.ReadLine());
        }

        private static void PrintIfIsPalindrome(string s)
        {
            s = s.ToLower();
            string r = "";
            for (int i = s.Length; i >= 1; i--)
                r += s[i - 1];

            if (s.Equals(r))
                Console.WriteLine("'" + s + "' is a palindrome");
            else
                Console.WriteLine("'" + s + "' is not a palindrome");
        }
    }
}
