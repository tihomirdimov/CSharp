using System;
using System.Collections.Generic;
using System.Linq;
class JoinLists
{
    static void Main()
    {
        List<int> firstSet = new List<int>();
        string[] firstInput = Console.ReadLine().Split();
        for (int i = 0; i < firstInput.Length; i++)
        {
            firstSet.Add(int.Parse(firstInput[i]));
        }
        List<int> secondSet = new List<int>();
        string[] secondInput = Console.ReadLine().Split();
        for (int i = 0; i < secondInput.Length; i++)
        {
            secondSet.Add(int.Parse(secondInput[i]));
        }
        List<int> outputSet = new List<int>();
        outputSet = firstSet;
        foreach (int number in secondSet)
        {
            if (!firstSet.Contains(number))
            {
                outputSet.Add(number);
            }
            else
            {
                continue;
            }
        }
        List<int> outputUniqueValues = new List<int>();
        outputUniqueValues = outputSet.Distinct().ToList();
        outputUniqueValues.Sort();
        foreach (int number in outputUniqueValues)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();
    }
}