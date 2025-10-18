using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Text { get; set; }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Text}\n");
    }
}
