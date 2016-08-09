//points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.SummertimeForProgrammers
{
    class SummertimeForProgrammers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("{1}{0}{1}", new string('*', n + 1), new string(' ', ((n * 2) - (n + 1)) / 2));
            for (int i = 1; i <= (n - 1) / 2; i++)
            {
                Console.WriteLine("{1}*{0}*{1}", new string(' ', (n - 1)), new string(' ', ((n * 2) - (n + 1)) / 2));
            }
            for (int i = ((n - 1)/2); i >= 1; i--)
            {
                Console.WriteLine("{1}*{0}*{1}", new string(' ', (2*n-2-2*i)), new string(' ',i));
            }
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("*{0}*", new string('.', (n* 2) - 2));
            }
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("*{0}*", new string('@', (n* 2) - 2));
            }
            Console.WriteLine("{0}", new string('*', n* 2));
        }
    }
}
