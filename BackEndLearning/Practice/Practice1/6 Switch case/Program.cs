using System.Linq.Expressions;

namespace _6_Switch_case
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double salary = 5000;
            Console.WriteLine("Enter Level: A / B / C / D / E");
            string level = Console.ReadLine().ToLower();
            switch (level)
            {
                case "a":
                    salary += 500;
                    break;
                case "b":
                    salary += 200;
                    break;
                case "c":
                     break;
                case "d":
                    salary -= 200;
                    break;
                case "e":
                    salary -= 500;
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    break;
            }
            Console.WriteLine($"Salary is ${salary}.");
        }
    }
}
