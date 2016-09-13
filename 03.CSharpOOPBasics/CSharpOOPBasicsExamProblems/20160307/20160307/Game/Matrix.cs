using System;

namespace _20160307.Models
{
    public class Matrix
    {
        private readonly MatrixElement[,] matrix;
        public Matrix(int rows, int columns)
        {
            matrix = new MatrixElement[rows, columns];
        }
        public void Populate(int row, int col, char value)
        {
            switch (value)
            {
                case 'A':
                    matrix[row, col] = new Asparagus();
                    break;
                case 'B':
                    matrix[row, col] = new Broccoli();
                    break;
                case 'C':
                    matrix[row, col] = new CherryBerry();
                    break;
                case 'M':
                    matrix[row, col] = new Mushroom();
                    break;
                case 'R':
                    matrix[row, col] = new Royal();
                    break;
                case '-':
                    matrix[row, col] = new BlankSpace();
                    break;
            }
        }
        public void Grow()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j].Grow();
                }
                Console.WriteLine();
            }
        }

        public int[] FindPlayerPosition(char player)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] position = new int[2];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j].Equals(player))
                    {
                        position[0] = i;
                        position[1] = j;
                    }
                }
            }
            return position;
        }
    }
}