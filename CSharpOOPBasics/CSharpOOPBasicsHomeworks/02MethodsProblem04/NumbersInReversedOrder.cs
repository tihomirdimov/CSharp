using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02MethodsProblem04
{
    class NumbersInReversedOrder
    {
        class DecimalNumber
        {
            public string number;
            public DecimalNumber(string number)
            {
                this.number = number;
            }
            public string Reversed()
            {
                StringBuilder reversed = new StringBuilder();
                for (int i = this.number.Length - 1; i >= 0; i--)
                {
                    reversed.Append(this.number[i]);
                }
                return reversed.ToString();
            }
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            DecimalNumber number = new DecimalNumber(input);
            Console.WriteLine(number.Reversed());
        }
    }
}