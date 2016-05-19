//points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class MagicWand
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int width = 3 * n + 2;
        Console.WriteLine("{0}*{0}", new string('.', (width - 1) / 2));
        for (int i = 1; i <= n; i += 2)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', (width - 2 - i) / 2), new string('.', i));
        }
        //middle

        Console.WriteLine("{0}{1}{0}", new string('*', n), new string('.', n + 2));
        for (int i = 1; i <= (n - 1) / 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', i), new string('.', width - 2 * i - 2));
        }
        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.WriteLine("{3}*{2}*{1}*{0}*{1}*{2}*{3}",
                new string('.', n), new string('.', i),
                new string('.', (n - 1) / 2), new string('.', (width - 6 - n - (n - 1) - 2 * i) / 2));
        }
        Console.WriteLine("{2}{1}*{0}*{1}{2}",
                new string('.', n), new string('.', ((n - 1) / 2)),
                new string('*', ((width - n - 2 - (n - 1)) / 2)   ));
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}*{0}*{0}", new string('.', n));
        }
        Console.WriteLine("{0}{1}{0}", new string('.', n), new string('*', n + 2));
    }
}