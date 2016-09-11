namespace _20160307.Game
{
    using System.Collections.Generic;
    using _20160307.Models;
    public static class GameStructure
    {
        private static List<Ninja> Players = new List<Ninja>();
        private static Matrix Matrix;
        private static char[] controls;
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
        public static char[] Controls { get; set; }
    }
}