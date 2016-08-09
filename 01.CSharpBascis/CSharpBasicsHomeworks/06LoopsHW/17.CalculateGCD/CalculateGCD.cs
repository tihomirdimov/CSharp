using System;
class CalculateGCD
{
    static void Main()
    {
        Console.WriteLine("Please enter value for a");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter value for b");
        int b = int.Parse(Console.ReadLine());
        int remainder = int.MaxValue;
        if (a > b)
        {
            while (remainder > 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }
            Console.WriteLine("GCD: {0}", a);
        }
        else
        {
            while (remainder > 0)
            {
                remainder = b % a;
                b = a;
                a = remainder;
            }
            Console.WriteLine("GCD: {0}", b);
        }
    }
}