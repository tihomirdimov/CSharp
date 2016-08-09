using System;
using System.Numerics;
class CatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("Please enter value for n");
        int n = int.Parse(Console.ReadLine());
        if (n > 1 && n < 100)
        {
            BigInteger factorial2N = 1;
            for (int i = 1; i <= (n*2); i++)
            {
                factorial2N *= i;
            }
            BigInteger factorialNPlusOne = 1;
            for (int i = 1; i <= (n+1); i++)
            {
                factorialNPlusOne *= i;
            }
            BigInteger factorialN = 1;
            for (int i = 1; i <= n; i++)
            {
                factorialN *= i;
            }
            BigInteger catalanNo = factorial2N/(factorialNPlusOne*factorialN);
            Console.WriteLine("Catalan ({0}): {1}", n, catalanNo);
        }
        else
        {
            Console.WriteLine("Wrong input");
        }
    }
}