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
        public List<double> Score { get; set; }
        public List<int> StudentIds { get; set; }
        public int Hours { get; set; }

        public Course(int id, string courseName, int hours)
        {
            Id = id;
            CourseName = courseName;
            Hours = hours;
            Score = new List<double>(); // Initializes an empty list for Score
            StudentIds = new List<int>();
        }
    }
}
