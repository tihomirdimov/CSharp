using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02MethodsProblem03
{
    class Number
    {
        string number;
        public Number(string number)
        {
            this.number = number;
        }
        public string returnLastDigit()
        {
            char last = this.number.ToCharArray()[this.number.Length-1];
            switch (last)
            {
                
                case '1':
                    return "one";
                case '2':
                    return "two";
                case '3':
                    return "three";
                case '4':
                    return "four";
                case '5':
                    return "five";
                case '6':
                    return "six";
                case '7':
                    return "seven";
                case '8':
                    return "eight";
                case '9':
                    return "nine";
                case '0':
                    return "zero";
                default:
                    return "";
            }
        }
    }

    class LastDigitName
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Number number = new Number(input);
            Console.WriteLine(number.returnLastDigit());
        }
    }
}
