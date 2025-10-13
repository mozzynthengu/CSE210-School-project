using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Set up scripture reference and text
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        // Main loop
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // You can change how many words to hide
        }

        Console.Clear();
        Console.WriteLine("All words are hidden. Great job memorizing!");
    }
}
