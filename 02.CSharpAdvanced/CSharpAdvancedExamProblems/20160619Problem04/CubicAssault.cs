using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20160619Problem04
{
    class CubicAssault
    {
        public static Dictionary<string, int[]> regionsDb = new Dictionary<string, int[]>();
        static void Main(string[] args)
        {
            string patternGreen = "(.*)\\s*\\-\\>\\s*(Green)\\s*\\-\\>\\s*([0-9]+)";
            string patternRed = "(.*)\\s*\\-\\>\\s*(Red)\\s*\\-\\>\\s*([0-9]+)";
            string patternBlack = "(.*)\\s*\\-\\>\\s*(Black)\\s*\\-\\>\\s*([0-9]+)";
            
            string input = Console.ReadLine();
            while (!input.Equals("Count em all"))
            {
                if (Regex.IsMatch(input, patternGreen))
                {
                    Regex regex = new Regex(patternGreen);
                    Match match = regex.Match(input);
                    AddRegion(match.Groups[1].Value);
                }
                else if (Regex.IsMatch(input, patternRed))
                {
                    Regex regex = new Regex(patternRed);
                    Match match = regex.Match(input);
                    AddRegion(match.Groups[1].Value);
                }
                else if (Regex.IsMatch(input, patternBlack))
                {
                    Regex regex = new Regex(patternBlack);
                    Match match = regex.Match(input);
                    AddRegion(match.Groups[1].Value);
                }
                input = Console.ReadLine();
            }
            foreach (var region in regionsDb)
            {
                Console.WriteLine(region.Key);
            }
        }
        public static void AddRegion(string region)
        {
            //Array indexes 0-green, 1-red, 2-black
            if (!regionsDb.ContainsKey(region))
            {
                regionsDb.Add(region, new int[3]);
            }
            //else
            //{
            //    if (type.Equals("red", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        var temp = regionsDb[region].GetValue();
            //    }
            //}
        }
    }
}
