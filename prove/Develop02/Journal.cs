using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        Console.WriteLine("\nYour Journal Entries:\n");
        foreach (Entry entry in entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveToFile(string filename)
    {
        List<string> lines = new List<string>();
        foreach (Entry entry in entries)
        {
            lines.Add($"{entry.Date}|{entry.Prompt}|{entry.Text}");
        }
        File.WriteAllLines(filename, lines);
        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry
                    {
                        Date = parts[0],
                        Prompt = parts[1],
                        Text = parts[2]
                    };
                    entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
