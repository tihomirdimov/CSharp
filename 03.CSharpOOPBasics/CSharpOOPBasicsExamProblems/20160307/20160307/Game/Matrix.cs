namespace _20160307.Models
{
    public class Matrix
    {
        private char[,] matrix;
        public Matrix(int rows, int columns)
        {
            matrix = new char[rows,columns];
        }
        public void Populate(int row, int col, char control)
        {
            matrix[row, col] = control;
        }
    }
}
