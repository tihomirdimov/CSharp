using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem05ConvertFromBaseNToBase10
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] tokens = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        double numBase = double.Parse(tokens[0]);
        char[] num = tokens[1].Reverse().ToArray();
        double result = 0;
        for (int i = 0; i < num.Length; i++)
        {
            result += (Convert.ToInt32(new string(num[i], 1))) * Math.Pow(numBase, i);
        }
        Console.WriteLine(result);
    }
}