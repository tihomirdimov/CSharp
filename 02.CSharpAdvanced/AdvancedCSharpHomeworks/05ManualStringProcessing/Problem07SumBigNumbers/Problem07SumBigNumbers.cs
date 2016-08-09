using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem07SumBigNumbers
{
    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();
        if (first.Length >= second.Length)
        {
            sumNums(first, second);
        }
        else
        {
            sumNums(second, first);
        }
    }
    public static void sumNums(string str1, string str2)
    {
        int lengthDif = 0;
        if (str1.Length == str2.Length)
        {
            lengthDif = 0;
        }
        else
        {
            lengthDif = str1.Length - str2.Length;
        }
    }
    public static int calculateSum(string str1, string str2, string dif)
    {
        int result = 0;
        int remainder = 0;
        for (int i = str1.Length - 1; i >= (0 + dif.Length); i++)
        {
            result += Convert.ToInt32(new string(str1[i], 1)) + Convert.ToInt32(new string(str2[i], 1));
        }
        return result;
    }
}