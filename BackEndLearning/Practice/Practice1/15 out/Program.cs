namespace _15_out
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message;
            Console.WriteLine("please input your username");
            string username = Console.ReadLine();
            Console.WriteLine("please input your password");
            string password = Console.ReadLine();

            bool isLogin = Login(username, password, out message);

            if (isLogin)
            {
                Console.WriteLine($"Successful! {message}");
            }
            else
            {
                Console.WriteLine($"Sorry, {message}");
            }
        }
        public static bool Login(string username, string password, out string message)
        {
            if (username != "admin")
            {
                message = "username is incorrect";
                return false;
            }
            else if (password != "88888")
            {
                message = "password is incorrect";
                return false;
            }
            message = "Welcome admin";
            return true;

        }
    }
}
