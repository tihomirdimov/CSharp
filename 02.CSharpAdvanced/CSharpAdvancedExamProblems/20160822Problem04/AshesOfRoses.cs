using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20160822Problem04
{
    class AshesOfRoses
    {
        public static Dictionary<string, Dictionary<string, int>> regions = new Dictionary<string, Dictionary<string, int>>();
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"Grow\s{1}\<([A-Z]{1}[a-z]+)\>\s{1}\<([A-Za-z0-9]+)\>\s{1}([0-9]*)";
            while (!input.Equals("Icarus, Ignite!"))
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(input);
                    addRegion(match.Groups[1].Value, match.Groups[2].Value, int.Parse(match.Groups[3].Value));
                }
                input = Console.ReadLine();
            }
            var regionsToPrint = regions.OrderByDescending(r => r.Value.Sum(y => y.Value)).ThenBy(x => x.Key);
            foreach (var region in regionsToPrint)
            {
                Console.WriteLine(region.Key);
                var rosesToPrint = region.Value.OrderBy(c => c.Value).ThenBy(c => c.Key);
                foreach (var rose in rosesToPrint)
                {
                    Console.WriteLine("*--{0} | {1}",rose.Key, rose.Value);
                }
            }
        }
        public static void addRegion(string region, string color, int flowers)
        {
            if (!regions.ContainsKey(region))
            {
                regions.Add(region, new Dictionary<string, int>());
                regions[region].Add(color, flowers);
            }
            else
            {
                if (!regions[region].ContainsKey(color))
                {
                    regions[region].Add(color, flowers);
                }
                else
                {
                    regions[region][color] += flowers;
                }
            }
        }
    }
}