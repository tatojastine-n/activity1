using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRankTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            Console.WriteLine("Enter at least 10 student names and their scores (format: Name Score). Type 'done' to finish:");

            while (students.Count < 10)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "done" && students.Count >= 10)
                    break;

                string[] parts = input.Split(' ');
                if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                {
                    students.Add(new Student(parts[0], score));
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter in the format: Name Score");
                }
            }
            var rankedStudents = students
            .OrderByDescending(s => s.Score)
            .ThenBy(s => s.Name)
            .Take(3)
            .ToList();

            Console.WriteLine("\nTop 3 Students:");
            for (int i = 0; i < rankedStudents.Count; i++)
            {
                Console.WriteLine($"Rank {i + 1}: {rankedStudents[i].Name} with score {rankedStudents[i].Score}");
            }
        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Student(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}
