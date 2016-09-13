using System;

namespace _20160307.Game
{
    using System.Collections.Generic;
    using _20160307.Models;
    public static class GameStructure
    {
        private static List<Ninja> Players = new List<Ninja>();
        private static Matrix Matrix;
        private static char[] controls;
        private static int[] playerOnePosition;
        private static int[] playerTwoPosition;
        public static char[] Controls { get; set; }
        public static void AddPlayer(string player)
        {
            var newNinja = new Ninja(player);
            Players.Add(newNinja);
        }
        public static void CreateMatrix(int row, int col)
        {
            Matrix = new Matrix(row, col);
        }
        public static void PopulateMatrix(int row, int col, char value)
        {
            Matrix.Populate(row, col, value);
        }
        public static void CreateControls(char[] inputControls)
        {
            Controls = inputControls;
        }

        public static void FindStartPositions()
        {
            char firstName = Players[0].Name[0];
            char secondName = Players[1].Name[0];
            int rows = Matrix. , .GetLength(0);
            int cols = Matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j].Grow();
                }
                Console.WriteLine();
            }
        }
    }
}