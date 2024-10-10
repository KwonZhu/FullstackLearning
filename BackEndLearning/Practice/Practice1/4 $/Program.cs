namespace _4__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int time = 107653;

            // get days, hours, minutes, seconds
            int days = time / 86400;
            int remainingAfterDays = time % 86400;

            int hours = remainingAfterDays / 3600;
            int remainingAfterHours = remainingAfterDays % 3600;

            int minutes = remainingAfterHours / 60;
            int seconds = remainingAfterHours % 60;

            Console.WriteLine($"{time} seconds equals to {days} days, {hours} hours, {minutes} minutes and {seconds} seconds");
        }
    }
}
