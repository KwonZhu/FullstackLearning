using System.Collections;

namespace _10_For_loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int num = 100; num <= 999; num++)
            {
                //  
                //  the number to a string, each char to string, string to int, all ints to array
                var digits = num.ToString().Select(digit => int.Parse(digit.ToString())).ToArray();

                int hundred = digits[0];
                int ten = digits[1];
                int unit = digits[2];

                // Check if the number is a daffodil number
                if (num == (hundred* hundred * hundred) + (ten * ten * ten) + (unit * unit * unit))
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
