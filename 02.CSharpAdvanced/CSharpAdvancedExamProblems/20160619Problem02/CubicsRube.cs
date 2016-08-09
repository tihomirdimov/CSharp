using System;
using System.Collections.Generic;
using System.Linq;

namespace _20160619Problem02
{
    class CubicsRube
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int cellCount = size * size * size;
            long cellsWithParticleSum = 0;
            string input = Console.ReadLine();
            while (input != "Analyze")
            {
                string[] particles = input.Split(' ');
                int x = int.Parse(particles[0]);
                int y = int.Parse(particles[1]);
                int z = int.Parse(particles[2]);
                long particleValue = long.Parse(particles[3]);
                if (checkIsValidCell(size, x, y, z, particleValue))
                {
                    cellCount--;
                    cellsWithParticleSum += particleValue;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(cellsWithParticleSum);
            Console.WriteLine(cellCount);
        }
        public static bool checkIsValidCell(int size, int x, int y, int z, long value )
        {
            if (x < size && x >= 0 && y < size && y >= 0 && z < size && z >= 0 && value !=0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}