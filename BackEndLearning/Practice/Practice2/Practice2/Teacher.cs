using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }

        public Teacher(int id, string name)
        {
            ID = id;
            Name = name;
            Courses = new List<Course>();
        }

        public void PrintCourses(List<Student> students)
        {
            foreach (var course in Courses)
            {
                Console.WriteLine($"\n{Name} teaches {course.CourseName}");
                if (course.StudentIds.Count == 0)
                {
                    Console.WriteLine($"There is no enrollment for {course.CourseName}");
                }
                else
                {
                    foreach (var Id in course.StudentIds)
                    {
                        var student = students.Find(s => s.Id == Id);
                        Console.WriteLine($"Student : {student?.Name ?? "not found"}");
                    }
                }

            }
        }
        //public void PrintTeacherInfo(List<Student> students)
        //{
        //    Console.WriteLine($"Teacher: {Name} (ID: {ID}) teaches the following courses:");

        //    foreach (var course in Courses)
        //    {
        //        Console.WriteLine($"Course: {course.CourseName}, Hours: {course.Hours}");

        //        Console.WriteLine("Enrolled students:");
        //        foreach (var studentID in course.StudentIds)
        //        {
        //            var student = students.Find(s => s.Id == studentID);
        //            Console.WriteLine($"Student Name: {student.Name}, Age: {student.Age}");
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}

