using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160822Problem02
{
    class NaturesProphet
    {
        public static string input = Console.ReadLine();
        public static int[] gardenDimensions = input.Split().Select(int.Parse).ToArray();
        public static int[,] garden = new int[gardenDimensions[0], gardenDimensions[1]];
        static void Main()
        {
            input = Console.ReadLine();
            List<int[]> plantedflowers = new List<int[]>();
            while (!input.Equals("Bloom Bloom Plow"))
            {
                int[] plantedFlowerCoordinates = input.Split().Select(int.Parse).ToArray();
                plantedflowers.Add(plantedFlowerCoordinates);
                input = Console.ReadLine();
            }
            List<int[]> sorted = plantedflowers.OrderBy(x => x[0]).ThenBy(x => x[1]).ToList();
            foreach (var flower in sorted)
            {
                garden[flower[0], flower[1]]++;
                bloomIt(flower[0], flower[1]);
            }
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                List<int> flowersRow = new List<int>();
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    flowersRow.Add(garden[i, j]);
                }
                Console.Write(string.Join(" ", flowersRow.ToArray()));
                Console.WriteLine();
            }
        }
        public static void bloomIt(int row, int col)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                if (i != col)
                {
                    garden[row, i]++;
                }
            }
            for (int j = 0; j < garden.GetLength(1); j++)
            {
                if (j != row)
                {
                    garden[j, col]++;
                }
            }

        }
    }
}
