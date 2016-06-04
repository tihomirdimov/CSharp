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
    }
}