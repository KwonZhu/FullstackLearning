using System.Globalization;


namespace _7_Leap_year
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the query year:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the query month");
            int month = int.Parse(Console.ReadLine());

            Boolean isLeapYear = DateTime.IsLeapYear(year); //return true or false

            int days = DateTime.DaysInMonth(year, month);

            System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.DateTimeFormatInfo();
            String strMonthName = dtfi.GetMonthName(month).ToString(); //convert int to month name

            Console.WriteLine($"{year} is {(isLeapYear ? "leap year" : "not leap year")}");
            Console.WriteLine($"There are {days} days in {strMonthName} of {year}");

        }
    }
}
