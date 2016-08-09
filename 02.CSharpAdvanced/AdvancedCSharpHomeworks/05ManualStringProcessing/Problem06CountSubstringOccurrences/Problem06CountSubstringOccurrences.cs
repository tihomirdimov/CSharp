using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem06CountSubstringOccurrences
{
    static void Main()
    {
        string input = Console.ReadLine();
        string toFind = Console.ReadLine();
        int counter = 0;
        for (int i = 0; i < input.Length - toFind.Length-1; i++)
        {
            if (toFind.Equals(input.Substring(i, toFind.Length), StringComparison.InvariantCultureIgnoreCase))
            {
                counter++;
            }
            else
            {
                continue;
            }
        }
        Console.WriteLine(counter);
    }
}