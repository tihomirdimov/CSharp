using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem04CountSymbols
{
    public static SortedDictionary<char, int> occurances = new SortedDictionary<char, int>();
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        foreach (char letter in input)
        {
            countOccurances(letter);
        }
        foreach (KeyValuePair<char, int> occurance in occurances)
        {
            Console.WriteLine("{0}: {1} time/s", occurance.Key, occurance.Value);
        }
    }
    public static void countOccurances(char letter)
    {
        if (occurances.ContainsKey(letter))
        {
            int occ = 0;
            if (occurances.TryGetValue(letter, out occ))
            {
                occurances[letter] = occ + 1;
            }
            else
            {
                occurances.Add(letter, 1);
            }
        }
        else
        {
            occurances.Add(letter, 1);
        }
    }
}