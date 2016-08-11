using System;
using System.Linq;

namespace _20160613Problem02
{
    class JediGalaxy
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] galaxyDimensions = input.Split(' ').Select(int.Parse).ToArray();
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
            long result = 0;
            int galaxyRows = galaxy.GetLength(0);
            int galaxyCols = galaxy.GetLength(1);
            input = Console.ReadLine();
            while (!input.Equals("Let the Force be with you"))
            {
                int[] moveI = input.Split(' ').Select(int.Parse).ToArray();
                input = Console.ReadLine();
                if (input.Equals("Let the Force be with you"))
                {
                    break;
                }
                int[] moveDV = input.Split(' ').Select(int.Parse).ToArray();
                while (checkIfInGalaxy(moveDV[0] - 1, moveDV[1] - 1, galaxyRows, galaxyCols))
                {
                    galaxy[moveDV[0] - 1, moveDV[1] - 1] = 0;
                    moveDV[0]--;
                    moveDV[1]--;
                }
                while (checkIfInGalaxy(moveI[0] - 1, moveI[1] + 1, galaxyRows, galaxyCols))
                {
                    result += galaxy[(moveI[0] - 1), (moveI[1] + 1)];
                    moveI[0]--;
                    moveI[1]++;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(result);
        }
        public static bool checkIfInGalaxy(int row, int col, int galaxyCol, int galaxyRow)
        {
            if (row >= 0 && row < galaxyRow && col >= 0 && col < galaxyCol)
            {
                return true;
            }
            return false;
        }
    }
}