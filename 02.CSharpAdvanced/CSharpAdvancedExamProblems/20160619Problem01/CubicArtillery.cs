using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _20160619Problem01
{
    class CubicArtillery
    {
        static void Main()
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            var bunkers = new Queue<string>();
            var weapons = new Queue<int>();
            int freeBunkerCapacity = maxCapacity;
            Regex rgx = new Regex("[a-zA-Z]");
            string input = Console.ReadLine();
            while (input != "Bunker Revision")
            {
                string[] items = input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in items)
                {
                }
                input = Console.ReadLine();
            }
        }
    }
}