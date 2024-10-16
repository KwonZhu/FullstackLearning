namespace Practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>
            {
                new CSharp(1, 30),
                new HTML(2, 6),
                new React(3, 30),
            };

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher(1, "Lily"),
                new Teacher(2, "Peng"),
                new Teacher(3, "Justin"),
            };

            List<Student> students = new List<Student>
            {
                new Student(1, "Melody", 20),
                new Student(2, "Ryan", 21),
                new Student(3, "Princess", 22),
                new Student(4, "Owen ", 23),
                new Student(5, "Barbara ", 24),
                new Student(6, "Santino", 25),
                new Student(7, "Ari", 20),
                new Student(8, "Marvin ", 21),
                new Student(9, "Lexie", 22),
                new Student(10, "Teresa", 23),
            };

            teachers[0].Courses.Add(courses[0]);
            teachers[1].Courses.Add(courses[1]);
            teachers[2].Courses.Add(courses[2]);

            ////establish the two-way relationship
            courses[0].StudentIds.Add(students[0].Id);
            students[0].Courses.Add(courses[0]);
            courses[0].StudentIds.Add(students[1].Id);
            students[1].Courses.Add(courses[0]);
            courses[0].StudentIds.Add(students[2].Id);
            students[2].Courses.Add(courses[0]);

            courses[1].StudentIds.Add(students[3].Id);
            students[3].Courses.Add(courses[1]);
            courses[1].StudentIds.Add(students[4].Id);
            students[4].Courses.Add(courses[1]);


            courses[2].StudentIds.Add(students[5].Id);
            students[5].Courses.Add(courses[2]);
            courses[2].StudentIds.Add(students[5].Id);
            students[6].Courses.Add(courses[2]);

            foreach (var teacher in teachers)
            {
                teacher.PrintCourses(students);
            }

            Console.WriteLine("bbb");
            Console.WriteLine("aaaa");
            Console.ReadKey();
        }
    }
}
