using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public List<double> Scores { get; set; }
        public List<int> StudentIds { get; set; }
        public int Hours { get; set; }

        public Course(int id, string courseName, int hours)
        {
            Id = id;
            CourseName = courseName;
            Hours = hours;
            Scores = new List<double>(); // Initializes an empty list for Score
            StudentIds = new List<int>();
        }

        public void Top3Students(List<Student> students)
        {
            if (Scores.Count == 0)
            {
                Console.WriteLine($"No students enrolled in {CourseName}.");
                return;
            }
            // Create a list of indexes sorted by the score in descending order
            var top3Indexes = Scores
                .Select((score, index) => new { Score = score, Index = index }) // Create a list of score and index pairs
                .OrderByDescending(s => s.Score)
                .ThenBy(s => StudentIds[s.Index]) //If scores are equal, sort by student ID (ascending)
                .Take(Math.Min(3, Scores.Count))  // Take up to 3 students
                .Select(s => s.Index)
                .ToList();

            Console.WriteLine($"\nTop {(Scores.Count() < 3 ? Scores.Count() : 3)} students in {CourseName} Course are:");

            foreach (var index in top3Indexes)
            {
                var student = students.Find(s => s.Id == StudentIds[index]);
                Console.WriteLine($"Student: {student.Name}, Score: {Scores[index]}");
            }
        }
    }
}