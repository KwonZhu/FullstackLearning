namespace StudentInfo
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of students you want to store");
            int length = int.Parse(Console.ReadLine());
            Student[] students = new Student[length];

            //get input form user
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"\nEnter information for student {i + 1}:");
                students[i] = new Student();

                Console.Write("Name: ");
                string name = Console.ReadLine();
                while (name.Length < 2 || name.Length > 30)
                {
                    Console.WriteLine("Error: Name length should be between 2 and 30 characters. Please input again.");
                    name = Console.ReadLine();
                }
                students[i].Name = name;

                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());
                while (age < 18 || age > 60)
                {
                    Console.WriteLine("Error: Age should be between 18 and 60. Please input again");
                    age = int.Parse(Console.ReadLine());
                }
                students[i].Age = age;

                Console.WriteLine("Course: ");
                students[i].Course = Console.ReadLine();
            }

            // print all students without sorting
            Console.WriteLine("\nStudent information:");
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
            }

            //use LINQ to do sorting by age
            var sortedStudents = students.OrderBy(s => s.Age);
            Console.WriteLine("\nStudents sorted by age: ");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
            }

            //use LINQ to do search
            Console.WriteLine("\nPlease enter a student name to search");
            string queryName = Console.ReadLine();
            var queryStudents = students.Where(s => s.Name.Equals(queryName, StringComparison.OrdinalIgnoreCase));
            //return ture if it contians any elements
            if (queryStudents.Any())
            {
                foreach (var student in queryStudents)
                {
                    Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
                }
            }
            else
            {
                Console.WriteLine($"{queryName} not exist.");
            }
        }
    }
}
