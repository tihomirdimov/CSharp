using System;
using System.Linq;

namespace _20160313Problem01
{
    class ArrangeNumbers
    {
        public class ArrangeIntegersMain
        {
            public static void Main()
            {
                string[] IntegerNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                Console.WriteLine(string.Join(", ", Console.ReadLine()
                        .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .OrderBy(str => string.Join(string.Empty, str.Select(ch => IntegerNames[ch - '0'])))));
            }
        }
    }
}
