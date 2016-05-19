using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Problem01UniqueUsernames
{
    static void Main(string[] args)
    {
        string line = Console.ReadLine();
        HashSet<string> usernames = new HashSet<string>();
        while (line != null)
        {
            line = Console.ReadLine();
            usernames.Add(line);
        }
        foreach (string user in usernames)
        {
            Console.WriteLine(user);
        }
    }
}