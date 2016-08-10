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
        public static Dictionary<string, Dictionary<string, long>> regionsDb = new Dictionary<string, Dictionary<string, long>>();
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
                    AddRegion(match.Groups[1].Value, match.Groups[2].Value, long.Parse(match.Groups[3].Value));
                }
                else if (Regex.IsMatch(input, patternRed))
                {
                    Regex regex = new Regex(patternRed);
                    Match match = regex.Match(input);
                    AddRegion(match.Groups[1].Value, match.Groups[2].Value, long.Parse(match.Groups[3].Value));
                }
                else if (Regex.IsMatch(input, patternBlack))
                {
                    Regex regex = new Regex(patternBlack);
                    Match match = regex.Match(input);
                    AddRegion(match.Groups[1].Value, match.Groups[2].Value, long.Parse(match.Groups[3].Value));
                }
                input = Console.ReadLine();
            }
            var toPrintRegions = regionsDb.OrderByDescending(r => r.Value["Black"]).ThenBy(r=>r.Key.Length).ThenBy(r=>r.Key);
            foreach (var region in toPrintRegions)
            {
                Console.WriteLine(region.Key);
                foreach (var stone in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {stone.Key} : {stone.Value}");
                }
            }
        }
        public static void AddRegion(string region, string type, long value)
        {
            if (!regionsDb.ContainsKey(region))
            {
                regionsDb.Add(region, new Dictionary<string, long>());
                regionsDb[region].Add("Green", 0);
                regionsDb[region].Add("Red", 0);
                regionsDb[region].Add("Black", 0);
                regionsDb[region][type] += value;
                AboveOneM(region);
            }
            else
            {
                regionsDb[region][type] += value;
                AboveOneM(region);
            }
        }
        public static void AboveOneM(string region)
        {
            long remainder;
            long m;
            long value = regionsDb[region]["Green"];
            if (value >= 1000000)
            {
                remainder = value % 1000000;
                m = value / 1000000;
                regionsDb[region]["Green"] = remainder;
                regionsDb[region]["Red"] += m;
                AboveOneM(region);
            }
            value = regionsDb[region]["Red"];
            if (value >= 1000000)
            {
                remainder = value % 1000000;
                m = value / 1000000;
                regionsDb[region]["Red"] = remainder;
                regionsDb[region]["Black"] += m;
                AboveOneM(region);
            }
        }
    }
}
