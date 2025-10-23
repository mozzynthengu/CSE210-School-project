using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    public void DisplayScore()
    {
        _level = (_score / 1000) + 1;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nCurrent Score: {_score} | Level: {_level}");
        Console.ResetColor();
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        int pointsEarned = _goals[index].RecordEvent();
        int oldLevel = _level;

        _score += pointsEarned;
        if (_score < 0) _score = 0;

        _level = (_score / 1000) + 1;

        if (_level > oldLevel)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n LEVEL UP! You reached Level {_level}!");
            Console.ResetColor();
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"{_score},{_level}");
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);
        string[] firstLine = lines[0].Split(",");
        _score = int.Parse(firstLine[0]);
        _level = int.Parse(firstLine[1]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] details = parts[1].Split(",");

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2]), bool.Parse(details[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]),
                        int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(details[0], details[1], int.Parse(details[2])));
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}
