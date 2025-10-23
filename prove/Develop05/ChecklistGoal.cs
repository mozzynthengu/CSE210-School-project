using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            int earnedPoints = _points;

            if (IsComplete())
            {
                earnedPoints += _bonusPoints;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Goal complete! You earned {_points} + {_bonusPoints} bonus points!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Progress made! You earned {_points} points! ({_currentCount}/{_targetCount})");
                Console.ResetColor();
            }

            return earnedPoints;
        }
        else
        {
            Console.WriteLine("This goal is already complete!");
            return 0;
        }
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetDetails()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_targetCount},{_bonusPoints},{_currentCount}";
    }
}
