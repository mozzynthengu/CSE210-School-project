<<<<<<< HEAD
using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you did something truly selfless.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?",
        "What is your favorite thing about this experience?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times when you've shown strength and resilience.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nPrompt:");
        Console.WriteLine($"-- {GetRandomPrompt()} --");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"> {GetRandomQuestion()}");
            ShowSpinner(6);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }
}
=======
using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you did something truly selfless.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?",
        "What is your favorite thing about this experience?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times when you've shown strength and resilience.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nPrompt:");
        Console.WriteLine($"-- {GetRandomPrompt()} --");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"> {GetRandomQuestion()}");
            ShowSpinner(6);
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }
}
>>>>>>> 339c483 (Finish Develop04 Mindfulness Program)
