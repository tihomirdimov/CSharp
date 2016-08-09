using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20160619Problem03
{
    class CubicMessages
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (!input.Equals("Over!"))
            {
                int charNum = int.Parse(Console.ReadLine());
                string pattern = string.Format("^([0-9]+)([a-zA-Z]{{{0}}})([^a-zA-Z]*)$", charNum);
                if (Regex.IsMatch(input, pattern))
                {
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(input);
                    char[] numbersBefore = match.Groups[1].Value.ToCharArray();
                    var msg = match.Groups[2].Value;
                    char[] numbersAfter = match.Groups[3].Value.ToCharArray();
                    StringBuilder result = new StringBuilder();
                    foreach (var item in numbersBefore)
                    {
                        int num = int.Parse(item.ToString());
                        if (num >= 0 && num < msg.Length)
                        {
                            result.Append(msg[num]);
                        }
                        else
                        {
                            result.Append(' ');
                        }
                    }
                    foreach (var item in numbersAfter)
                    {
                        if (Char.IsDigit(item))
                        {
                            int num = int.Parse(item.ToString());
                            if (num >= 0 && num < msg.Length)
                            {
                                result.Append(msg[num]);
                            }
                            else
                            {
                                result.Append(' ');
                            }
                        }
                    }
                    Console.WriteLine("{0} == {1}", msg, result);
                }
                input = Console.ReadLine();
            }
        }
    }
}
