using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out guess))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue; // Skips the rest of the loop and asks again
            }

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            } 
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower"); // Added missing semicolon
            }
            else 
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
