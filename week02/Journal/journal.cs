using System;
using System.Collections.Generic;
using System.IO;
using JournalApp;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> entries = new List<Entry>();

        public void AddEntry(string prompt, string response)
        {
            entries.Add(new Entry(prompt, response));
        }

        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries available.");
                return;
            }

            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine(entry);
                }
            }
            Console.WriteLine($"Journal saved successfully to {filename}.");
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new Entry(parts[1].Trim(), parts[2].Trim()) { Date = parts[0].Trim() });
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
    }
}
