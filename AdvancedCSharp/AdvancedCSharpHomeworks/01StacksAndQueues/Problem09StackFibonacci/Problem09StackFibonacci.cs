using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem09StackFibonacci
{
    public static Stack<long> fibNumbers = new Stack<long>();
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        Console.WriteLine(calculateFibonacci(input));
    }
    public static long calculateFibonacci(long n)
    {
        fibNumbers.Push(1);
        fibNumbers.Push(1);
        long currentFibNum = 0;
        for (int i = 2; i < n; i++)
        {
            long[] temp = fibNumbers.ToArray();
            currentFibNum = temp[0] + temp[1];
            fibNumbers.Push(currentFibNum);
        }
        return fibNumbers.Peek();
    }
}