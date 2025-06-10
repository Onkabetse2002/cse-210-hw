using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();

            string choice = "";
            while (choice != "7")
            {
                goalManager.DisplayScore();
                //Exceeding Requirements: Leveling System
                goalManager.DisplayLevel();

                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Create Negative Goal");
                Console.WriteLine("  7. Quit");
                Console.Write("Select a choice from the menu: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        goalManager.CreateGoal();
                        break;
                    case "2":
                        goalManager.ListGoals();
                        break;
                    case "3":
                        goalManager.SaveGoals();
                        break;
                    case "4":
                        goalManager.LoadGoals();
                        break;
                    case "5":
                        goalManager.RecordEvent();
                        break;
                    case "6":
                        goalManager.CreateNegativeGoal();
                        break;
                    case "7":
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
    //Exceeding Requirements:
    //I have added a leveling system that displays the user's current level and the points needed to reach the next level.
    //I have also added the ability to create negative goals that deduct points for bad habits.
}
