using System;

namespace _20160307.Models
{
    public class Matrix
    {
        private char[,] matrix;
        public Matrix(int rows, int columns)
        {
            matrix = new char[rows, columns];
        }
        public void Populate(int row, int col, char value)
        {
            matrix[row, col] = value;
        }
        public void Print()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}