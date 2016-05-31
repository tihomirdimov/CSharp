using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem02StringLength
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        StringBuilder output = new StringBuilder();
        if (input.Length > 20)
        {
            Console.WriteLine(input.Substring(0, 20));
        }
        else
        {
            for (int i = 0; i < input.Length; i++)
            {
                output.Append(input[i]);
            }
            char empty = '*';
            for (int i = output.Length; i < 20; i++)
            {
                output.Append(empty);
            }
            Console.WriteLine(output.ToString());
        }
    }
}