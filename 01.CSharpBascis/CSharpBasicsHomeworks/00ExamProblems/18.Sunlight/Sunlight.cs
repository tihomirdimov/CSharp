//points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Sunlight
{
    class Sunlight
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //top
            Console.WriteLine("{0}*{0}", new string('.', n + ((n - 1) / 2)));
            //middle-top
            for (int i = 1; i < n; i++)
            {
                Console.WriteLine("{1}*{0}*{0}*{1}", new string('.', (((3 * n) - 3 - (2 * i)) / 2)), new string('.', i));
            }
            //middle
            for (int i = 0; i < ((n - 1) / 2); i++)
            {
                Console.WriteLine("{1}{0}{1}", new string('*', n), new string('.', n));
            }
            Console.WriteLine("{0}", new string('*', 3 * n));
            for (int i = 0; i < ((n - 1) / 2); i++)
            {
                Console.WriteLine("{1}{0}{1}", new string('*', n), new string('.', n));
            }
            //middle-bottom
            for (int i = (n - 1); i >= 1; i--)
            {
                Console.WriteLine("{1}*{0}*{0}*{1}", new string('.', (((3 * n) - 3 - (2 * i)) / 2)), new string('.', i));
            }
            //bottom
            Console.WriteLine("{0}*{0}", new string('.', n + ((n - 1) / 2)));
        }
    }
}
