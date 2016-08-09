using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03StaticMembersProblem07
{
    class MathUtil
    {
        public static double Sum(double a, double b)
        {
            return a + b;
        }

        public static double Substract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            return a / b;
        }

        public static double Percentage(double a, double b)
        {
            return a * (b / 100);
        }
    }
    class BasicMath
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = Regex.Split(input, @"\s+");
                string command = data[0];
                double firstNum = double.Parse(data[1]);
                double secondNum = double.Parse(data[2]);
                switch (command)
                {
                    case "Sum":
                        Console.WriteLine("{0:F2}", MathUtil.Sum(firstNum, secondNum));
                        break;
                    case "Subtract":
                        Console.WriteLine("{0:F2}", MathUtil.Substract(firstNum, secondNum));
                        break;
                    case "Multiply":
                        Console.WriteLine("{0:F2}", MathUtil.Multiply(firstNum, secondNum));
                        break;
                    case "Divide":
                        Console.WriteLine("{0:F2}", MathUtil.Divide(firstNum, secondNum));
                        break;
                    case "Percentage":
                        Console.WriteLine("{0:F2}", MathUtil.Percentage(firstNum, secondNum));
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
