using System;
using System.Collections.Generic;

namespace NovusIntro.Completed
{
    class Problem1
    {
        public static void Solution()
        {
            List<int> nums = 
                new List<int> { 1, 2, 1, 1, 0, 3, 1, 0, 0, 2, 4, 1, 0, 0, 0, 0, 2, 1, 0, 3, 1, 0, 0, 0, 6, 1, 3, 0, 0, 0 };
            Console.WriteLine("List: " + string.Join(", ", nums));
            Console.WriteLine();

            int largestStreak = 0;
            int currentStreak = 0;
            foreach (int n in nums)
            {
                if (n == 0)
                {
                    currentStreak += 1;
                    if (currentStreak > largestStreak)
                        largestStreak = currentStreak;
                }
                else
                    currentStreak = 0;
            }
            Console.WriteLine("Largest streak of no sales was " + largestStreak);
        }
    }
}
