using System.Linq;

namespace _20160307
{
    using System;
    using System.IO;
    using _20160307.Game;
    class StartUp
    {
        static void Main()
        {
            string input = "";
            input = Console.ReadLine();
            Game.GameEngine.AddPlayer(input);
            input = Console.ReadLine();
            Game.GameEngine.AddPlayer(input);
            input = Console.ReadLine();
            int[] dimensions = input.Split(' ').Select(int.Parse).ToArray();
            Game.GameEngine.CreateMatrix(dimensions[0], dimensions[1]);
            for (int i = 0; i < dimensions[0]; i++)
            {
                input = Console.ReadLine();
                for (int j = 0; j < dimensions[1]; j++)
                {
                    Game.GameEngine.PopulateMatrix(i, j, input[j]);
                }
            }
            input = Console.ReadLine();
            char[] controls = input.ToCharArray();
            Game.GameEngine.CreateControls(controls);
        }
    }
}
