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
                    AddRegion(match.Groups[1].Value, match.Groups[2].Value, int.Parse(match.Groups[3].Value));
                }
                else if (Regex.IsMatch(input, patternRed))
                {
                    Regex regex = new Regex(patternRed);
                    Match match = regex.Match(input);
                    AddRegion(match.Groups[1].Value, match.Groups[2].Value, int.Parse(match.Groups[3].Value));
                }
                else if (Regex.IsMatch(input, patternBlack))
                {
                    Regex regex = new Regex(patternBlack);
                    Match match = regex.Match(input);
                    AddRegion(match.Groups[1].Value, match.Groups[2].Value, int.Parse(match.Groups[3].Value));
                }
                input = Console.ReadLine();
            }
            foreach (var region in regionsDb)
            {
                Console.WriteLine(region.Key);
                foreach (var item in region.Value)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public static void AddRegion(string region, string type, int value)
        {
            //Array indexes 0-green, 1-red, 2-black
            if (!regionsDb.ContainsKey(region))
            {
                regionsDb.Add(region, new int[3]);
                if (type.Equals("green", StringComparison.CurrentCultureIgnoreCase) || type.Equals("red", StringComparison.CurrentCultureIgnoreCase))
                {
                    int index = 0;
                    if (type.Equals("red", StringComparison.CurrentCultureIgnoreCase))
                    {
                        index = 1;
                    }
                    regionsDb[region][index] += value;
                    if (AboveOneM(regionsDb[region][index], value))
                    {
                        int remainder = (regionsDb[region][index] + value) % 1000000;
                        int m = regionsDb[region][index] / 1000000;
                        regionsDb[region][index] = remainder;
                        regionsDb[region][index + 1] += m;
                    }
                }
                else if (type.Equals("black", StringComparison.CurrentCultureIgnoreCase))
                {
                    regionsDb[region][2] += value;
                }
            }
            else
            {
                if (type.Equals("green", StringComparison.CurrentCultureIgnoreCase) || type.Equals("red", StringComparison.CurrentCultureIgnoreCase))
                {
                    int index = 0;
                    if (type.Equals("red", StringComparison.CurrentCultureIgnoreCase))
                    {
                        index = 1;
                    }
                    regionsDb[region][index] += value;
                    if (AboveOneM(regionsDb[region][index], value))
                    {
                        int remainder = (regionsDb[region][index] + value) % 1000000;
                        int m = regionsDb[region][index] / 1000000;
                        regionsDb[region][index] = remainder;
                        regionsDb[region][index + 1] += m;
                    }
                }
                else if (type.Equals("black", StringComparison.CurrentCultureIgnoreCase))
                {
                    regionsDb[region][2] += value;
                }
            }
        }
        public static bool AboveOneM(int toAdd, int curent)
        {
            if ((curent + toAdd) >= 1000000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
