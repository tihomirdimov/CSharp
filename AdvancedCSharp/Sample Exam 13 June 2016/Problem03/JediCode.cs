using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JediCode
{
    static void Main()
    {
        List<string> text = new List<string>();
        List<string> messages = new List<string>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            text.Add(Console.ReadLine());
        }
        string jediPattern = Console.ReadLine();
        string msgPattern = Console.ReadLine();
        int[] indexes = Console.ReadLine()
            .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(item => int.Parse(item))
            .ToArray();
        foreach (string line in text)
        {
            Console.WriteLine(line);
        }
        foreach (int index in indexes)
        {
            Console.WriteLine(index);
        }
    }
}