namespace _3_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int totalDays = 51;
           int weeks = totalDays / 7;
           int days = totalDays % 7;
            Console.WriteLine($"{totalDays} days equals to {weeks} weeks and {days} days.");
        }
    }
}
