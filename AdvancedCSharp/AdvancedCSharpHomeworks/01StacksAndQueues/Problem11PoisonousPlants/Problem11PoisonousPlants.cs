using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem11PoisonousPlants
{
    static void Main()
    {
        int plants = int.Parse(Console.ReadLine());
        int[] currentPlants = Console
            .ReadLine()
            .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(item => int.Parse(item))
            .ToArray();
        Stack<int[]> plantsLeft = new Stack<int[]>();
        plantsLeft.Push(currentPlants);
        bool allAlive = false;
        while (allAlive == false)
        {
            int[] temp = plantsLeft.Peek().ToArray();
            Queue<int> current = new Queue<int>();
            current.Enqueue(temp[0]);
            for (int i = 1; i <= temp.Length-1; i++)
            {
                if (temp[i] > temp[i - 1])
                {
                    continue;
                }
                else
                {
                    current.Enqueue(temp[i]);
                }
            }
            if (temp.Length == current.Count)
            {
                allAlive = true;
            }
            else
            {
                allAlive = false;
                plantsLeft.Push(current.ToArray());
            }
        }
        Console.WriteLine(plantsLeft.Count-1);
    }
}