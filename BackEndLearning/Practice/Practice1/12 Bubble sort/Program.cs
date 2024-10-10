namespace _12_Bubble_sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 4, 3, 9, 6, 8, 11 };
            int i, j, temp;
            bool swapped;

            for (i = 0; i < nums.Length - 1; i++)
            {
                swapped = false;
                for (j = 0; j < nums.Length - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        temp = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = temp;
                        swapped = true;
                    }
                }
                // no elements swap by for loop j, break in advance
                if (swapped == false)
                {
                    break;
                }
            }

            foreach (int k in nums)
            {
                Console.Write($"{k}, ");
            }
        }
    }
}
