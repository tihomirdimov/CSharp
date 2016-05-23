using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem05Phonebook
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Dictionary<String, String> phonebook = new Dictionary<string, string>();
        while (input != "search")
        {
            string[] elements = input
            .Split(new Char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
            phonebook.Add(elements[0], elements[1]);
            input = Console.ReadLine();
        }
        input = Console.ReadLine();
        string phoneNumber;
        while (input != "stop")
        {
            if (phonebook.TryGetValue(input, out phoneNumber))
            {
                Console.WriteLine("{0} -> {1}", input, phoneNumber);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", input);
            }
            input = Console.ReadLine();
        }
    }
}