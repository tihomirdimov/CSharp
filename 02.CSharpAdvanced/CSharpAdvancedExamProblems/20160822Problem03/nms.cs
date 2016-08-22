using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160822Problem03
{
    class nms
    {
        static void Main()
        {
            List<string> messages = new List<string>();
            string input = Console.ReadLine();
            StringBuilder temp = new StringBuilder();
            while (!input.Equals("---NMS SEND---"))
            {
                temp.Append(input);
                input = Console.ReadLine();
            }
            string text = temp.ToString().Trim();
            temp.Clear();
            for (int i = 0; i < text.Length-1; i++)
            {
                temp.Append(text[i]);
                if (char.ToUpperInvariant(text[i]) <= char.ToUpperInvariant(text[i + 1]))
                {
                    continue;
                }
                else
                {
                    messages.Add(temp.ToString());
                    temp.Clear();
                }
            }
            temp.Append(text[text.Length - 1]);
            messages.Add(temp.ToString());
            string delimiter = Console.ReadLine();
            Console.WriteLine(string.Join(delimiter, messages));
        }
    }
}