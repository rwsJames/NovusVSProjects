using System;
using System.Collections.Generic;
using System.Linq;

namespace NovusIntro
{
    class Problem2
    {
        private static List<string> words = new List<string>
            { "parts", "traps", "arts", "rats", "starts", "tarts", "rat", "art", "tar", "tars", "stars", "stray",
            "toy", "toys", "toyst" }; // Adding a few more examples allows us to see the generalisation work

        public static void Solution()
        {
            string compareTo = "star";

            // Since there can be no leftover letters, 
            // there is no need to check anything not the same length as what we want to check against
            words.RemoveAll((string s) => { return s.Length != compareTo.Length; });
            Console.WriteLine("Words same length as '" + compareTo + "' (" + compareTo.Length + "): ");
            foreach (string w in words)
                Console.WriteLine(w);
            Console.WriteLine();
            // The given set of words, from the question, that are of length 4 ONLY contains anagrams of "star",
            // so this removal is technically all that needs to be done

            // But to generalise it a little:
            Console.WriteLine("Valid anagrams of '" + compareTo + "': ");
            foreach (string w in words)
                // If w contains the same letters (we know it already has the right number of them) as our check, then...
                if (!w.Except(compareTo).Any())
                    Console.WriteLine(w);
        }
    }
}
