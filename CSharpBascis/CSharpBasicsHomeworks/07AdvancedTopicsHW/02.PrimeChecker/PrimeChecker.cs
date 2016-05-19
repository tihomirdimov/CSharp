using System;
class PrimeChecker
{
    static bool IsPrimeNumber(long n)
    {
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        long number = long.Parse(Console.ReadLine());
        bool result = IsPrimeNumber(number);
        Console.WriteLine(result);
    }
}