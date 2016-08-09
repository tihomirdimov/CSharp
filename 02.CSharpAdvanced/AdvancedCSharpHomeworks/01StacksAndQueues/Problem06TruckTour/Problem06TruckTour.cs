using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem06TruckTour
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Queue<long[]> pumps = new Queue<long[]>();
        for (int i = 0; i < n; i++)
        {
            long[] pumpToAdd = Console
                .ReadLine()
                .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(item => long.Parse(item))
                .ToArray();
            pumps.Enqueue(pumpToAdd);
        }
        for (int i = 0; i < n; i++)
        {
            if (isTourPossible(pumps))
            {
                Console.WriteLine(i);
                break;
            }
            else
            {
                pumps.Enqueue(pumps.Peek());
                pumps.Dequeue();
            }
        }
    }
    public static bool isTourPossible(Queue<long[]> pumpsToCheck)
    {
        long fuel = 0;
        foreach (long[] pumpToCheck in pumpsToCheck)
        {
            if ((pumpToCheck[0] + fuel) < pumpToCheck[1])
            {
                return false;
            }
            else
            {
                fuel += pumpToCheck[0];
                fuel -= pumpToCheck[1];
            }
        }
        return true;
    }
}