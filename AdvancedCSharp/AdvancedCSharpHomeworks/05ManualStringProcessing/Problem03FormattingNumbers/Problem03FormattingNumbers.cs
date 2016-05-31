using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem03FormattingNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] tokens = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int a = int.Parse(tokens[0]);
        double b = double.Parse(tokens[1]);
        double c = double.Parse(tokens[2]);
        string abin = Convert.ToString(a, 2).PadLeft(10, '0');
        Console.WriteLine("|{0,-10:X}|{1}|{2,10:F2}|{3,-10:F3}|", a, abin, b, c);
    }
}
//254	11,6	0,5