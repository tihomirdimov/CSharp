using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem06TruckTour
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int[]> pumps = new List<int[]>();
        for (int i = 0; i < n; i++)
        {
            int[] currentPump = Console
                .ReadLine()
                .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(item => int.Parse(item))
                .ToArray();
            pumps.Add(currentPump);
        }
        foreach (int[] pump in pumps)
        {
            if (pump[0] > pump[1]) {
                continue;
            }
        }
    }
}