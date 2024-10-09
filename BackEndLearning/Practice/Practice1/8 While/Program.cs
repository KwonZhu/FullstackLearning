namespace _8_While
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string answer = "";
            int count = 0;
            while (answer!="yes" & count < 10 )
            {
                Console.WriteLine("Do you know the answer? I can explain it to you. (yes/no)");
                answer = Console.ReadLine().ToLower();
                if (answer=="yes")
                {
                    Console.WriteLine("You can go home early");
                    break;
                }
                count++;
            }
            if (count==10)
            {
                Console.WriteLine("Times up, you can go home now");
            }
        }
    }
}
