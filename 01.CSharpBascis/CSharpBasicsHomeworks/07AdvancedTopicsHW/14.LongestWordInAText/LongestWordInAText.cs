using System;
using System.Collections.Generic;
using System.Linq;
class LongestWordInAText
{
    static void Main()
    {
        string input = Console.ReadLine();
        string line = input.Trim('.',',','?','!');
        string[] text = line.Split(' ');
        string longestWord = text[0];
        foreach (string word in text)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }
        Console.WriteLine("The longest word in the text is \"{0}\".", longestWord);
    }
}