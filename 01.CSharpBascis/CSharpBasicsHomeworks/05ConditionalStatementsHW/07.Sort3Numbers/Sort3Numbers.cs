using System;
class Sort3Numbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        if (a >= b && a >= b)
        {
            if (a >= b && b > c)
            {
                Console.WriteLine("{0} {1} {2}", a, b, c);
            }
            else if (a >= c && c > b)
            {
                Console.WriteLine("{0} {2} {1}", a, b, c);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", a, b, c);
            }
        }
        else if (b >= a && b >= c)
        {
            if (b >= a && a > c)
            {
                Console.WriteLine("{1} {0} {2}", a, b, c);
            }
            else if (b >= c && c > a)
            {
                Console.WriteLine("{1} {2} {0}", a, b, c);
            }
            else
            {
                Console.WriteLine("{1} {0} {2}", a, b, c);
            }
        }
        else if (c >= a && c >= b)
        {
            if (c >= a && a > b)
            {
                Console.WriteLine("{2} {0} {1}", a, b, c);
            }
            else if (c >= b && b > a)
            {
                Console.WriteLine("{2} {1} {0}", a, b, c);
            }
            else
            {
                Console.WriteLine("{2} {1} {0}", a, b, c);
            }
        }
    }
}