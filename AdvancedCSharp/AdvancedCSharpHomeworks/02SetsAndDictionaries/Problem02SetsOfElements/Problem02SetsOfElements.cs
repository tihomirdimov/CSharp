using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem02SetsOfElements
{
    static void Main(string[] args)
    {
        int[] numbers = Console
            .ReadLine()
            .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(item => int.Parse(item))
            .ToArray();
        int n = numbers[0];
        int m = numbers[1];
        HashSet<int> setN = new HashSet<int>();
        HashSet<int> setM = new HashSet<int>();
        int line = 0;
        for (int i = 0; i < n; i++)
        {
            line = int.Parse(Console.ReadLine());
            setN.Add(line);
        }
        for (int i = 0; i < m; i++)
        {
            line = int.Parse(Console.ReadLine());
            setM.Add(line);
        }
        HashSet<int> duplicates = new HashSet<int>();
        foreach (int elementN in setN)
        {
            foreach (int elementM in setM)
            {
                if (elementN == elementM)
                {
                    duplicates.Add(elementN);
                }
            }
        }
        foreach (int duplicate in duplicates)
        {
            Console.Write("{0} ",duplicate);
        }
    }
}