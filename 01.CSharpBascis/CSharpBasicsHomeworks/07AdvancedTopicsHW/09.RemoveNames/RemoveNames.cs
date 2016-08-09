using System;
using System.Collections.Generic;
using System.Linq;
class RemoveNames
{
    static void Main()
    {
        List<string> firstInput = new List<string>();
        string[] firstSet = Console.ReadLine().Split();
        for (int i = 0; i < firstSet.Length; i++)
        {
            firstInput.Add(firstSet[i]);
        }
        List<string> secondInput = new List<string>();
        string[] secondSet = Console.ReadLine().Split();
        for (int i = 0; i < secondSet.Length; i++)
        {
            secondInput.Add(secondSet[i]);
        }
        List<string> outputSet = new List<string>();
        foreach (var item in firstSet)
        {
            if (secondSet.Contains(item))
            {
                continue;
            }
            else
            {
                outputSet.Add(item);
            }
        }
        foreach (var name in outputSet)
        {
            Console.Write("{0} ", name);
        }
        Console.WriteLine();
    }
}