namespace _11_Nested_loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 10; i++)
            {
                // act as a right triangle
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j} * {i} = {j * i}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
