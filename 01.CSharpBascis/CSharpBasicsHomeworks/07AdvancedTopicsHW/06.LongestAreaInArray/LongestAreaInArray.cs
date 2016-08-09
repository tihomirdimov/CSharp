using System;
using System.Collections.Generic;
using System.Linq;
class LongestAreaInArray
{
    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        int number = int.Parse(Console.ReadLine());
        string[] strArray = new string[number];
        for (int i = 0; i < strArray.Length; i++)
        {
            strArray[i] = Console.ReadLine();
        }
        int counter = 1;
        int maxCounter = 1;
        int arrayIndex = 0;
        for (int i = 0; i < strArray.Length - 1; i++)
        {
            if (strArray[i] == strArray[i + 1])
            {
                counter++;
                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    arrayIndex = i - maxCounter + 2;
                }
            }
            else
            {
                counter = 1;
            }
        }
        Console.WriteLine(maxCounter);
        for (int i = arrayIndex; i < arrayIndex + maxCounter; i++)
        {
            Console.WriteLine(strArray[i]);
        }
    }
}