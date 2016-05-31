using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem01ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder output = new StringBuilder();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            output.Append(input[i]);
        }
        Console.WriteLine(output.ToString());
    }
}