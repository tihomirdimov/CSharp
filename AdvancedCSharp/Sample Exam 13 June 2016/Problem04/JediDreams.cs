using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
class JediDreams
{
    public static Dictionary<string, List<string>> db = new Dictionary<string, List<string>>();
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        string pattern = @"([A-Za-z0-9]*[A-Z]+[A-Za-z0-9]*)\s*\(";
        string currentMethod = "";
        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();
            if (input.Contains(" static "))
            {
                Match match = Regex.Match(input, pattern);
                currentMethod = match.Groups[1].ToString();
                db.Add(currentMethod, new List<string>());
            }
            else
            {
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match mtch in matches)
                {
                    {
                        db[currentMethod].Add(mtch.Groups[1].ToString());
                    }
                }
            }
        }
        var ordered = db.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key);
        foreach (KeyValuePair<string, List<string>> order in ordered)
        {
            if (order.Value.Count() == 0)
            {
                Console.WriteLine("{0} -> None", order.Key);
            }
            else
            {
                Console.Write("{0} -> {1} -> ", order.Key, order.Value.Count());
                var orderedInvoked = order.Value.OrderBy(x => x);
                var toPrint = string.Join(", ", orderedInvoked);
                Console.Write("{0}", toPrint);
                Console.WriteLine();
            }
        }
    }
}