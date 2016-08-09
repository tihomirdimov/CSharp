using System;
using System.Numerics;
class FactorialDivision2
{
    static void Main()
    {
        Console.WriteLine("Please enter value for n");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter value for k");
        int k = int.Parse(Console.ReadLine());
        int difference = n - k;
        if (k > 1 && k < n && n < 100)
        {
            BigInteger FacNVidK = 1;
            for (int i = k + 1; i <= n; i++)
            {
                FacNVidK *= i;
            }
            BigInteger FacNDifK = 1;
            for (int i = 1; i <= difference; i++)
            {
                FacNDifK *= i;
            }
            Console.WriteLine(FacNVidK / FacNDifK);
        }
        else
        {
            Console.WriteLine("Wrong input");
        }
    }
}