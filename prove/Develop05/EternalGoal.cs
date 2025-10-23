using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Great job! You earned {_points} points!");
        Console.ResetColor();
        return _points;
    }

    public override bool IsComplete() => false;

    public override string GetDetails()
    {
        return $"[∞] {_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name},{_description},{_points}";
    }
}
