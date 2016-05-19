using System;
using System.Numerics;
class TrailingZeroesinNFactorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }
        string factorialString = factorial.ToString();
        int counter = 0;
        for (int i = factorialString.Length - 1; i >= 0; i--)
        {
            if (factorialString[i] == '0')
            {
                counter++;
            }
            else
            {
                break;
            }
        }
        Console.WriteLine(counter);
    }
}