using System;

public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"You lost {_points} points for '{_name}'. Stay strong!");
        Console.ResetColor();
        return -_points;
    }

    public override bool IsComplete() => false;

    public override string GetDetails()
    {
        return $"[!] {_name} ({_description}) - Lose {_points} points when recorded";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_name},{_description},{_points}";
    }
}
