using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem04ConvertFromBase10ToBaseN
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] tokens = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int numBase = int.Parse(tokens[0]);
        int num = int.Parse(tokens[1]);
        StringBuilder result = new StringBuilder();
        int remainder1 = num % numBase;
        int remainder2 = num / numBase;
        result.Append(remainder1);
        num = remainder2;
        while (num > 0)
        {
            remainder1 =  num % numBase;
            remainder2 = num / numBase;
            result.Append(remainder1);
            num = remainder2;
        }
        Console.WriteLine(result.ToString().Reverse().ToArray());
    }
}