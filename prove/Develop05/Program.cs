using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== Eternal Quest Tracker ===");
        Console.ResetColor();

        while (running)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    manager.DisplayScore();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    manager.SaveGoals(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    manager.LoadGoals(Console.ReadLine());
                    break;
                case "5":
                    manager.DisplayGoals();
                    Console.Write("Enter the number of the goal you accomplished: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                        manager.RecordEvent(index - 1);
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye! Keep working toward your Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Types of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.Write("Choose a type: ");
        string choice = Console.ReadLine();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            case "4":
                manager.AddGoal(new NegativeGoal(name, desc, points));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }
}
