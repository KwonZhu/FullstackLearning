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
                new Teacher(2, "Ally"),
                new Teacher(3, "Justin"),
            };

            List<Student> students = new List<Student>
            {
                new Student(0, "Melody", 20),
                new Student(1, "Ryan", 21),
                new Student(2, "Princess", 22),
                new Student(3, "Owen ", 23),
                new Student(4, "Barbara ", 24),
                new Student(5, "Santino", 19),
                new Student(6, "Ari", 20),
                new Student(7, "Marvin ", 21),
                new Student(8, "Lexie", 22),
                new Student(9, "Teresa", 19),
            };

            teachers[0].Courses.Add(courses[0]);
            teachers[1].Courses.Add(courses[1]);
            teachers[2].Courses.Add(courses[2]);

            //establish the two-way relationship, then assign sorces to courses
            //CSharp
            courses[0].StudentIds.Add(students[0].Id);
            students[0].Courses.Add(courses[0]);
            courses[0].Scores.Add(90.0);
            courses[0].StudentIds.Add(students[1].Id);
            students[1].Courses.Add(courses[0]);
            courses[0].Scores.Add(96.3);

            //HTML
            courses[1].StudentIds.Add(students[2].Id);
            students[2].Courses.Add(courses[1]);
            courses[1].Scores.Add(90.0);
            courses[1].StudentIds.Add(students[3].Id);
            students[3].Courses.Add(courses[1]);
            courses[1].Scores.Add(93.6);
            courses[1].StudentIds.Add(students[4].Id);
            students[4].Courses.Add(courses[1]);
            courses[1].Scores.Add(90.0);
            courses[1].StudentIds.Add(students[5].Id);
            students[5].Courses.Add(courses[1]);
            courses[1].Scores.Add(92.5);

            //React
            courses[2].StudentIds.Add(students[6].Id);
            students[6].Courses.Add(courses[2]);
            courses[2].Scores.Add(93.5);
            courses[2].StudentIds.Add(students[7].Id);
            students[7].Courses.Add(courses[2]);
            courses[2].Scores.Add(97.5);
            courses[2].StudentIds.Add(students[8].Id);
            students[8].Courses.Add(courses[2]);
            courses[2].Scores.Add(85.5);
            courses[2].StudentIds.Add(students[9].Id);
            students[9].Courses.Add(courses[2]);
            courses[2].Scores.Add(94.8);

            foreach (var teacher in teachers)
            {
                teacher.PrintCourses(students);
            }

            foreach (var course in courses)
            {
                course.Top3Students(students);
            }
        }
    }
}