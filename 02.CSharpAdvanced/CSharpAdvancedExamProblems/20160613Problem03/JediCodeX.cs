using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _20160613Problem03
{
    class JediCodeX
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                text.Append(Console.ReadLine());
            }
            string pattern1 = Console.ReadLine();
            string pattern2 = Console.ReadLine();
            int[] indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string regexPattern1 = string.Format("({0})([A-Za-z]{{{1}}})(?![A-Za-z])", pattern1, pattern1.Length);
            string regexPattern2 = string.Format("({0})([A-Za-z0-9]{{{1}}})(?![A-Za-z0-9])", pattern2, pattern2.Length);
            Regex regex1 = new Regex(regexPattern1);
            Regex regex2 = new Regex(regexPattern2);
            List<string> jedi = new List<string>();
            List<string> messages = new List<string>();
            if (Regex.IsMatch(text.ToString(), pattern1))
            {
                MatchCollection matches = regex1.Matches(text.ToString());
                foreach (Match match in matches)
                {
                    jedi.Add(match.Groups[2].Value);
                }

            }
            if (Regex.IsMatch(text.ToString(), pattern2))
            {
                MatchCollection matches = regex2.Matches(text.ToString());
                foreach (Match match in matches)
                {
                    messages.Add(match.Groups[2].Value);
                }
            }
            int[] possition = indexes.Where(p => p <= messages.Count).ToArray();
            int[] validposition = possition.Take(Math.Min(jedi.Count, possition.Length)).ToArray();

            for (int i = 0; i < validposition.Length; i++)
            {
                Console.WriteLine(jedi[i] + " - " + messages[validposition[i] - 1]);
            }
        }
    }
}
