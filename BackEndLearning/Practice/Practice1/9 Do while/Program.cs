namespace _9_Do_while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            do
            {
                Console.WriteLine("input your name untill you input the letter 'q'");
                name = Console.ReadLine();
            }
            while (name !='q'.ToString());
        }
    }
}
