using System;

namespace HigherLower
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool isWinner = false;
                int target = (new Random()).Next(1, 100);

                Console.WriteLine("The computer has generated a number between 1 and 99.\nYou have 6 attempts to guess it.\n");

                int attempts = 0;
                while (attempts < 6)
                {
                    int guess = 0;

                    // Skip the first pass of printing this
                    if (guess != 0)
                        Console.WriteLine("You have " + (6 - attempts) + " attempts left.");

                    Console.WriteLine("Enter your number: ");
                    while (!Int32.TryParse(Console.ReadLine(), out guess))
                        Console.WriteLine("Enter your number: ");

                    Console.Clear();
                    if (guess == target)
                    {
                        isWinner = true;
                        break;
                    }
                    if (guess > target)
                    {
                        Console.WriteLine("INCORRECT.\nGuess lower.\n");
                    }
                    else // guess < target
                    {
                        Console.WriteLine("INCORRECT.\nGuess higher.\n");
                    }

                    attempts += 1;
                }



                if (isWinner)
                {
                    Console.WriteLine("You have triumphed. Press whatever you want to close the game.");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You have failed - the answer was " + target + ".  Let's try this again.\n");
                }
            }

            // Catch the user when they win so they can see they won
            Console.ReadLine();
        }
    }
}
