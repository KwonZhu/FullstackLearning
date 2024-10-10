namespace _13_MaxValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = MaxValue(100, 1000);
            Console.WriteLine(max);
        }

        public static int MaxValue(int n1, int n2) 
        { 
            return n1 > n2 ? n1 : n2;
        }
    }
}
