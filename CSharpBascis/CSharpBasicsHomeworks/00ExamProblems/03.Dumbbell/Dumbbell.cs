//points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Dumbbell
{
    class Dumbbell
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //top
            for (int i = (n - 1) / 2; i > 0; i--)
            {
                if (i == (n - 1) / 2)
                {
                    Console.WriteLine("{0}&{1}&{2}&{1}&{0}", new string('.', i), new string('&', n - i - 2), new string('.', n));
                }
                else
                {
                    Console.WriteLine("{0}&{1}&{2}&{1}&{0}", new string('.', i), new string('*', n - i - 2), new string('.', n));
                }
            }
            //middle
            int star = n - 2;
            int lines = n;
            Console.WriteLine("&{0}&{1}&{0}&", new string('*', star), new string('=', n));
            //bottom body
            for (int i = 1; i <= (n - 1) / 2; i++)
            {
                if (i == (n - 1) / 2)
                {
                    Console.WriteLine("{0}&{1}&{2}&{1}&{0}", new string('.', i), new string('&', n - i - 2), new string('.', n));
                }
                else
                {
                    Console.WriteLine("{0}&{1}&{2}&{1}&{0}", new string('.', i), new string('*', n - i - 2), new string('.', n));
                }
            }
        }
    }
}