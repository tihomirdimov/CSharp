using System;
using System.Linq;
using System.Numerics;

namespace _20160613Problem02
{
    class JediGalaxy
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int[] galaxyDimensions = input.Split().Select(int.Parse).ToArray();
            int[,] galaxy = new int[galaxyDimensions[0], galaxyDimensions[1]];
            int count = 0;
            for (int i = 0; i < galaxyDimensions[0]; i++)
            {
                for (int j = 0; j < galaxyDimensions[1]; j++)
                {
                    galaxy[i, j] = count;
                    count++;
                }
            }
            BigInteger result = 0;
            int galaxyRows = galaxy.GetLength(0);
            int galaxyCols = galaxy.GetLength(1);
            input = Console.ReadLine();
            while (!input.Equals("Let the Force be with you"))
            {
                int[] moveI = input.Split().Select(int.Parse).ToArray();
                int ivoRow = moveI[0];
                int ivoCol = moveI[1];
                input = Console.ReadLine();
                int[] moveDV = input.Split().Select(int.Parse).ToArray();
                int dvRow = moveDV[0];
                int dvCol = moveDV[1];
                while (dvRow >= 0 && dvCol >= 0)
                {
                    if (checkIfInGalaxy(dvRow, dvCol, galaxyRows, galaxyCols))
                    {
                        galaxy[dvRow, dvCol] = 0;
                    }
                    dvRow--;
                    dvCol--;

                }
                while (ivoRow >= 0 && ivoCol < galaxyCols)
                {
                    if (checkIfInGalaxy(ivoRow, ivoCol, galaxyRows, galaxyCols))
                    {
                        result += galaxy[ivoRow, ivoCol];
                    }
                    ivoRow--;
                    ivoCol++;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(result);
        }
        public static bool checkIfInGalaxy(int row, int col, int galaxyRows, int galaxyCols)
        {
            if (row >= 0 && row < galaxyRows && col >= 0 && col < galaxyCols)
            {
                return true;
            }
            return false;
        }
    }
}