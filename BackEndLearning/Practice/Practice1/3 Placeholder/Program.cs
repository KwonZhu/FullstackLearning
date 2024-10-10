namespace _3_Placeholder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalDays = 51;
            int weeks = totalDays / 7;
            int days = totalDays % 7;
            Console.WriteLine("{0} days equals to {1} weeks and {2} days.", totalDays, weeks, days);
        }
    }
}


