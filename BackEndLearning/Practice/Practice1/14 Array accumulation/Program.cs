namespace _14_Array_accumulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 4, 3, 9, 6, 8, 11 };
            int sum = 0 ;
            for (int i = 0; i < nums.Length; i++)
            {
                 sum += nums[i];
            }
            Console.WriteLine($"the accumulation result is {sum}");
        }
    }
}
