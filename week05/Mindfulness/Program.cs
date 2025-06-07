using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        MindfulnessApp app = new MindfulnessApp();
        app.Run();
    }
}

class MindfulnessApp
{
    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Start();
                    break;
                case "2":
                    new ReflectionActivity().Start();
                    break;
                case "3":
                    new ListingActivity().Start();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

abstract class Activity
{
    protected int duration;

    public void Start()
    {
        Console.WriteLine(GetStartingMessage());
        Console.Write("Enter duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        Pause(3);

        PerformActivity();

        Console.WriteLine("Good job! You completed the activity.");
        Console.WriteLine($"Duration: {duration} seconds.");
        Pause(3);
    }

    protected abstract string GetStartingMessage();
    protected abstract void PerformActivity();

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rPausing for {i} seconds... ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : Activity
{
    protected override string GetStartingMessage()
    {
        return "Breathing Activity: This activity will help you relax by walking you through breathing in and out slowly.";
    }

    protected override void PerformActivity()
    {
        int cycles = duration / 4; // 4 seconds per cycle
        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            Pause(4);
            Console.WriteLine("Breathe out...");
            Pause(4);
        }
    }
}

class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    protected override string GetStartingMessage()
    {
        return "Reflection Activity: This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(5); // Give time to think

        int endTime = Environment.TickCount + (duration * 1000);
        while (Environment.TickCount < endTime)
        {
            string question = questions[rand.Next(questions.Count)];
            Console.WriteLine(question);
            Pause(5); // Pause for reflection
        }
    }
}

class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    protected override string GetStartingMessage()
    {
        return "Listing Activity: This activity will help you reflect on the good things in your life by having you list as many things as you can.";
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Pause(5); // Give time to think

        List<string> items = new List<string>();
        int endTime = Environment.TickCount + (duration * 1000);
        while (Environment.TickCount < endTime)
        {
            Console.Write("Enter an item (or type 'done' to finish): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;
            items.Add(input);
        }

        Console.WriteLine($"You listed {items.Count} items.");
    }
}
