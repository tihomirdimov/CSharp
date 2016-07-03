using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
class Problem02
{
    public static int size = int.Parse(Console.ReadLine());
    public static Dictionary<string, long> rube = new Dictionary<string, long>();
    static void Main()
    {
        string input = Console.ReadLine();
        long changed = 0;
        while (input != "Analyze")
        {
            string[] particles = input.Split(' ');
            int x = int.Parse(particles[0]);
            int y = int.Parse(particles[1]);
            int z = int.Parse(particles[2]);
            long particleValue = long.Parse(particles[3]);
            string key = x.ToString() + y.ToString() + z.ToString();
            if (checkIfEmpyty(key, x, y, z))
            {
                rube[key] = particleValue;
                if (particleValue == 0)
                {
                    changed++;
                }
            }
            input = Console.ReadLine();
        }
        BigInteger sum = 0;
        foreach (KeyValuePair<string, long> cell in rube)
        {
            sum += cell.Value;
        }
        Console.WriteLine(sum);
        Console.WriteLine(size * size * size - rube.Count() - changed);
    }
    public static bool checkIfEmpyty(string key, int x, int y, int z)
    {
        if (!rube.ContainsKey(key) && x < size && x >= 0 && y < size && y >= 0 && z < size && z >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}