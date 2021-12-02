using System;
using System.Collections.Generic;
using System.Linq;

namespace NovusIntro
{
    class Problem8
    {
        public static void Solution()
        {
            List<int> nums = new List<int>() { 3, 1, 5, 7, 5, 9 };
            Console.WriteLine("List: " + string.Join(", ", nums));

            int target;
            Console.WriteLine("\nPlease input a target value for two items from the above list (max. 18): ");
            while (!Int32.TryParse(Console.ReadLine(), out target))
                Console.WriteLine("\nPlease input a target value for two items from the above list (max. 18): ");

            List<Tuple<int, int>> tuples = FindAllTwoSum(nums, target);

            if (tuples.Any())
            {
                foreach (Tuple<int, int> t in tuples)
                    Console.WriteLine("List indexes " + t.Item1 + " and " + t.Item2 + " (values of " + nums[t.Item1] + " and " + nums[t.Item2] + ") sum to " + target);

                Console.WriteLine("\nOf these indexes, these are unique: ");
                // Remove the tuples with reversed indexes at the end of the list, this +1 saves the non-duplicated tuple where the indexes are equal
                tuples.RemoveRange(tuples.Count / 2, tuples.Count - (tuples.Count + 1) / 2);
                foreach (Tuple<int, int> t in tuples)
                    Console.WriteLine("List indexes " + t.Item1 + " and " + t.Item2 + " (values of " + nums[t.Item1] + " and " + nums[t.Item2] + ") sum to " + target);
            }
            else
                Console.WriteLine("\nNo two values in the list sum to " + target);
        }

        private static List<Tuple<int, int>> FindAllTwoSum(List<int> l, int target)
        {
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();

            // Basically one pass of a bubble sort but testing for the total of two not which is greater or lesser
            for (int i = 0; i < l.Count; i++)
                for (int j = 0; j < l.Count - i; j++)
                    if (l[i] + l[j] == target)
                        tuples.Add(new Tuple<int, int>(i, j));

            return tuples;
        }
    }
}
