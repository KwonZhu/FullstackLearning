namespace _16_ref
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 1;
            int num2 = 10;

            Swap(ref num1, ref num2);
            Console.WriteLine($"num1 and num2 have been swapped, num1 is {num1}, num2 is {num2}");
        }
        public static void Swap(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }
    }
}
