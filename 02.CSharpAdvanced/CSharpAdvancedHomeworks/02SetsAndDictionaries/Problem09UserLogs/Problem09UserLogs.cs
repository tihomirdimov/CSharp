using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
class Problem09UserLogs
{
    static void Main()
    {
        string input = Console.ReadLine();
        Regex pattern = new Regex(@"IP=(.*?) message='(?:.*)' user=(.*)");
        while (input != "end")
        {
            input = Console.ReadLine();
        }
        Console.WriteLine();
    }
}