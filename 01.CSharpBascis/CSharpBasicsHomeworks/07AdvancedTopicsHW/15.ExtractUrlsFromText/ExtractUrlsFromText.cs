using System;
using System.Collections.Generic;
using System.Linq;
class ExtractUrlsFromText
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] text = input.Split(' ');
        List<string> urlList = new List<string>();
        foreach (string word in text)
        {
            if (!urlList.Contains(word) && word.Length > 6)
            {
                if (word.Substring(0, 7) == "http://" || word.Substring(0, 4) == "www.")
                {
                    //trims all '.',',','?','!' at the end of the string
                    if (word.EndsWith(".") || word.EndsWith(",") || word.EndsWith("?") || word.EndsWith("!"))
                    {
                        urlList.Add(word.TrimEnd('.', ',', '?', '!'));
                    }
                    else
                    {
                        urlList.Add(word);
                    }
                }
            }
        }
        foreach (string word in urlList)
        {
            Console.WriteLine(word);
        }
    }
}