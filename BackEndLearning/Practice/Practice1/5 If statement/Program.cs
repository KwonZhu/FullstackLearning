namespace _5_If_statement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();

            if (userName == "admin") {
                if (password == "88888")
                {
                    Console.WriteLine("Correct input!");
                }
                else {
                    Console.WriteLine("Incorrect password");
                }
            }
            else
            {
                Console.WriteLine("Incorrect username");
            }



        }
    }
}
