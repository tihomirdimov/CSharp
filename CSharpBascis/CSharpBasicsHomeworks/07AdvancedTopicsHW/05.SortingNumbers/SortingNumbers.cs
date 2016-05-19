using System;
using System.Collections.Generic;
using System.Linq;
class SortingNumbers
{
    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        int number = int.Parse(Console.ReadLine());
        int[] numArray = new int[number];
        for (int i = 0; i < numArray.Length; i++)
        {
            numArray[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(numArray);
        foreach (var item in numArray)
        {
            Console.WriteLine(item);
        }
    }
}