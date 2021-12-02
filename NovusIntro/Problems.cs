using NovusIntro.Completed;
using System;

namespace NovusIntro
{
    class Problems
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int option = 0;
                Console.WriteLine("If you wish to change any of the values with no prompt, please directly edit the file. \n");
                Console.WriteLine("Please input a number from 1 to 10 to see the solution to the problem. (0 to exit)");
                Console.Write("Problem number: ");
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    Console.Clear();
                    switch (option)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;
                        case 1:
                            Problem1.Solution();
                            break;
                        case 2:
                            Problem2.Solution();
                            break;
                        case 3:
                            Problem3.Solution();
                            break;
                        case 4:
                            Problem4.Solution();
                            break;
                        case 5:
                            Problem5.Solution();
                            break;
                        case 6:
                            Problem6.Solution();
                            break;
                        case 7:
                            Problem7.Solution();
                            break;
                        case 8:
                            Problem8.Solution();
                            break;
                        case 9:
                            Problem9.Solution();
                            break;
                        case 10:
                            Problem10.Solution();
                            break;
                        default:
                            Console.WriteLine("\nPlease try again.");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nPlease try again.");
                }

                Console.WriteLine();
                Console.Write("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n");
            }
        }
    }
}
