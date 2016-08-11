using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160613Problem01
{
    class JediMeditation
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input;
            List<string> jedi = new List<string>();
            bool yoda = false;
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                var current = input.Split(' ').ToList();
                foreach (var person in current)
                {
                    jedi.Add(person);
                    if (person.Contains("y"))
                    {
                        yoda = true;
                    }
                }
            }
            var masters = jedi.Where(j => j.Contains("m")).ToList();
            var knights = jedi.Where(j => j.Contains("k")).ToList();
            var padawans = jedi.Where(j => j.Contains("p")).ToList();
            var ts = jedi.Where(j => j.Contains("t") || j.Contains("s")).ToList();
            string printMasters = string.Join(" ", masters.ToArray());
            string printKinghts = string.Join(" ", knights.ToArray());
            string printPadawans = string.Join(" ", padawans.ToArray());
            string printTs = string.Join(" ", ts.ToArray());
            if (yoda)
            {
                Console.WriteLine("{0} {1} {2} {3}", printMasters, printKinghts, printTs, printPadawans);
            }
            else
            {
                Console.WriteLine("{0} {1} {2} {3}", printTs, printMasters, printKinghts, printPadawans);
            }
        }
    }
}
