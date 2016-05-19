//points 90 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.PetarsGame
{
    class PetarsGame
    {
        static long Calculation(long num)
        {
            long remainder = 0;
            if (num % 5 == 0)
            {
                return num;
            }
            else
            {
                remainder = num % 5;
                return remainder;
            }
        }
        static void Main(string[] args)
        {
            StringBuilder output = new StringBuilder();
            long startNum = long.Parse(Console.ReadLine());
            long endNum = long.Parse(Console.ReadLine());
            string replacement = Console.ReadLine();
            long sum = 0;
            long tempSum = 0;
            for (long i = startNum; i <= endNum - 1; i++)
            {
                tempSum = Calculation(i);
                sum += tempSum;
            }
            bool isOdd = false;
            if (sum % 2 == 0)
            {
                isOdd = false;
            }
            else
            {
                isOdd = true;
            }
            string result = Convert.ToString(sum);
            if (isOdd == false)
            {
                output.Append(replacement);
                for (int i = 1; i < result.Length; i++)
                {
                    if (result[i] == result[0])
                    {
                        output.Append(replacement);
                    }
                    else
                    {
                        output.Append(result[i]);
                    }
                }
                Console.WriteLine(output);
            }
            else
            {
                List<string> outputStr = new List<string>();
                for (int i = result.Length - 1; i >= 0; i--)
                {
                    if (result[i] == result[result.Length - 1])
                    {
                        outputStr.Add(replacement);
                    }
                    else
                    {
                        outputStr.Add(result[i].ToString());
                    }
                }
                outputStr.Reverse();
                foreach (string cell in outputStr)
                {
                    Console.Write(cell);
                }
                Console.WriteLine();
            }
        }
    }
}