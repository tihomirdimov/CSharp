using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
class Problem03
{
    static void Main()
    {
        string pattern = @".*([0-9]+)\s*([A-Za-z]+)\s*([0-9]*).*";
        string message = Console.ReadLine();
        while (message != "Over!")
        {
            string input = Console.ReadLine();
            int m = int.Parse(input);
            Match match = Regex.Match(message, pattern);
            if (match.Success)
            {
                string prefix = match.Groups[1].ToString();
                string msg = match.Groups[2].ToString();
                string surfix = match.Groups[3].ToString();
                bool isChar = false;
                for (int i = (match.Groups[2].Index-1 + match.Groups[2].Length); i < input.Length-1; i++)
                {
                    if (Char.IsLetter(message[i]))
                    {
                        isChar = true;
                    }
                }
                if (msg.Length == m && isChar == false)
                {
                    StringBuilder stringBld = new StringBuilder();
                    foreach (char ch in prefix)
                    {
                        stringBld.Append(getChar(ch, msg));
                    }
                    if (surfix.Length > 0)
                    {
                        foreach (char ch in surfix)
                        {
                            stringBld.Append(getChar(ch, msg));
                        }
                    }
                    string toPrint = stringBld.ToString();
                    int countCh = 0;
                    foreach (char ch in toPrint)
                    {
                        if (ch != ' ')
                        {
                            countCh++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (countCh > 0)
                    {
                        Console.WriteLine(@"{0} == {1}", msg, toPrint);
                    }
                }
            }
            message = Console.ReadLine();
        }
    }
    public static char getChar(char inputCh, string input)
    {
        int currentIndex = (int)inputCh - 48;
        if (currentIndex >= 0 && currentIndex < input.Length)
        {
            return input[currentIndex];
        }
        else
        {
            return ' ';
        }
    }
}