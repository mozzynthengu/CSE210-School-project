<<<<<<< HEAD
using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "What are things you're grateful for today?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list them.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nPrompt:");
        Console.WriteLine($"-- {GetRandomPrompt()} --");
        Console.WriteLine("You will begin listing in 5 seconds...");
        ShowCountDown(5);

        Console.WriteLine("Start listing items (press Enter after each, type 'done' to finish early):");

        List<string> entries = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "done") break;
                entries.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {entries.Count} items.");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
=======
using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "What are things you're grateful for today?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list them.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nPrompt:");
        Console.WriteLine($"-- {GetRandomPrompt()} --");
        Console.WriteLine("You will begin listing in 5 seconds...");
        ShowCountDown(5);

        Console.WriteLine("Start listing items (press Enter after each, type 'done' to finish early):");

        List<string> entries = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "done") break;
                entries.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {entries.Count} items.");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
>>>>>>> 339c483 (Finish Develop04 Mindfulness Program)
