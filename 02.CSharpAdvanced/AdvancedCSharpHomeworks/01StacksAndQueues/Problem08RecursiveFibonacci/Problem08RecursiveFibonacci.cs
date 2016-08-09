using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem08RecursiveFibonacci
{
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        Console.WriteLine(calculateFibonacci(input));
    }
    public static long calculateFibonacci(long n)
    {
        if (n <= 2)
        {
            return 1;
        }
        else
        {
            n = calculateFibonacci(n - 1) + calculateFibonacci(n - 2);
            return n;
        }
    }
}