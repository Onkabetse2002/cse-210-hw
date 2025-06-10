using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string goalType = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            Goal newGoal = null;

            switch (goalType)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int timesToComplete = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(name, description, points, timesToComplete, bonusPoints);
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    return;
            }

            if (newGoal != null)
            {
                _goals.Add(newGoal);
                Console.WriteLine("Goal created successfully!");
            }
        }

        public void RecordEvent()
        {
            ListGoals();
            Console.Write("Which goal did you accomplish? ");
            int goalNumber = int.Parse(Console.ReadLine()) - 1;

            if (goalNumber >= 0 && goalNumber < _goals.Count)
            {
                int pointsEarned = _goals[goalNumber].RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"You earned {pointsEarned} points!");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        public void ListGoals()
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].DisplayGoal()}");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"Your total score is: {_score}");
        }

        public void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    outputFile.WriteLine(_score); // Save the score
                    foreach (Goal goal in _goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine("Goals saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        public void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            try
            {
                _goals.Clear(); // Clear existing goals
                _score = 0;

                string[] lines = File.ReadAllLines(filename);
                if (lines.Length > 0)
                {
                    _score = int.Parse(lines[0]); // Load the score

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] parts = lines[i].Split(':');
                        if (parts.Length == 2)
                        {
                            string goalType = parts[0];
                            string[] goalData = parts[1].Split(',');

                            Goal newGoal = null;

                            switch (goalType)
                            {
                                case "SimpleGoal":
                                    string name = goalData[0];
                                    string description = goalData[1];
                                    int points = int.Parse(goalData[2]);
                                    bool isComplete = bool.Parse(goalData[3]);
                                    newGoal = new SimpleGoal(name, description, points);
                                    if (isComplete)
                                    {
                                        newGoal.RecordEvent();
                                    }
                                    break;
                                case "EternalGoal":
                                    name = goalData[0];
                                    description = goalData[1];
                                    points = int.Parse(goalData[2]);
                                    newGoal = new EternalGoal(name, description, points);
                                    break;
                                case "ChecklistGoal":
                                    name = goalData[0];
                                    description = goalData[1];
                                    points = int.Parse(goalData[2]);
                                    int timesToComplete = int.Parse(goalData[3]);
                                    int bonusPoints = int.Parse(goalData[4]);
                                    int timesCompleted = int.Parse(goalData[5]);
                                    newGoal = new ChecklistGoal(name, description, points, timesToComplete, bonusPoints);
                                    for (int j = 0; j < timesCompleted; j++)
                                    {
                                        newGoal.RecordEvent();
                                    }
                                    break;
                                case "NegativeGoal":
                                    name = goalData[0];
                                    description = goalData[1];
                                    points = int.Parse(goalData[2]);
                                    newGoal = new NegativeGoal(name, description, points);
                                    break;
                            }

                            if (newGoal != null)
                            {
                                _goals.Add(newGoal);
                            }
                        }
                    }
                }

                Console.WriteLine("Goals loaded successfully!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }

        //Exceeding Requirements: Leveling System
        public void DisplayLevel()
        {
            int level = _score / 1000 + 1;
            int pointsToNextLevel = 1000 - (_score % 1000);
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Points to next level: {pointsToNextLevel}");
        }

        //Exceeding Requirements: Negative Goals/Habits
        public void CreateNegativeGoal()
        {
            Console.Write("What is the name of your negative goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points deducted for this goal? ");
            int points = int.Parse(Console.ReadLine());

            NegativeGoal newGoal = new NegativeGoal(name, description, points);
            _goals.Add(newGoal);
            Console.WriteLine("Negative goal created successfully!");
        }
    }
}
