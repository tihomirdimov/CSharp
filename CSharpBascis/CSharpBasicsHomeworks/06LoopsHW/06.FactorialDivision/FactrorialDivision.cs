using System;
using System.Numerics;
class FactrorialDivision
{
    static void Main()
    {
        Console.WriteLine("Please enter value for n");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter value for k");
        int k = int.Parse(Console.ReadLine());
        if (k > 1 && k < n && n < 100)
        {
            BigInteger result = 1;
            for (int i = k+1; i <= n ; i++)
            {
                result *= i;
            }
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Wrong input");
        }
    }
}