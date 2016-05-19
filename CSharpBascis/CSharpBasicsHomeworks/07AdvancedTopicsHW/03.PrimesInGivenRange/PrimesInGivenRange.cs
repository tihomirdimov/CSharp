using System;
using System.Collections.Generic;
using System.Linq;
class PrimesInGivenRange
{
    static List<int> PrimeNumbersInRange(int startNum, int endNum)
    {
        List<int> primeNumbers = new List<int>();
        int diviser = 0;
        for (int i = startNum; i <= endNum; i++)
        {
            for (int j = 2; j < i; j++)
            {
                if (i % j != 0)
                {
                    diviser++;
                }
            }
            if (diviser == i - 2)
            {
                primeNumbers.Add(i);
            }
            diviser = 0;
        }
        return primeNumbers;
    }
    static void Main()
    {
        Console.WriteLine("Please enter start number:");
        int start = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter end number:");
        int end = int.Parse(Console.ReadLine());
        List<int> result = PrimeNumbersInRange(start, end);
        foreach (int item in result)
        {
            Console.Write("{0}, ", item);
        }
    }
}