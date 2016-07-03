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
                    break;
                case '2':
                    return "two";
                    break;
                case '3':
                    return "three";
                    break;
                case '4':
                    return "four";
                    break;
                case '5':
                    return "five";
                    break;
                case '6':
                    return "six";
                    break;
                case '7':
                    return "seven";
                    break;
                case '8':
                    return "eight";
                    break;
                case '9':
                    return "nine";
                    break;
                case '0':
                    return "zero";
                    break;
                default:
                    return "";
                    break;
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
