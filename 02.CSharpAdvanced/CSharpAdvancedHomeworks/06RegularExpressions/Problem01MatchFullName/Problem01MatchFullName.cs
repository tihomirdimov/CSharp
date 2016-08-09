using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
class Problem01MatchFullName
{
    static void Main()
    {
        string input = Console.ReadLine();
        while (input != "end")
        {
            string pattern = "\b([A-Z]+[a-z]+)[' ']+([A-Z]+[a-z]+)\b";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            Console.WriteLine("{0} {1}", match.Groups[0], match.Groups[1]);
            input = Console.ReadLine();
        }
        
    }
}