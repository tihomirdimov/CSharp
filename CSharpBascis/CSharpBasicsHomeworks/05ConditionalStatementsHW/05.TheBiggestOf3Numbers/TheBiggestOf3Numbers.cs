using System;
class TheBiggestOf3Numbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        if (a > b && a > c)
        {
            Console.WriteLine(a);
        }
        else if (b > a && b > c)
        {
            Console.WriteLine(b);
        }
        else if (c > a && c > b)
        {
            Console.WriteLine(c);
        }
        else if (a == b && a > c)
        {
            Console.WriteLine("{0} {1}", a, b);
        }
        else if (a == c && a > b)
        {
            Console.WriteLine("{0} {1}", a, c);
        }
        else if (b == c && b > a)
        {
            Console.WriteLine("{0} {1}", b, c);
        }
        else
        {
            Console.WriteLine("{0} {1} {2}", a, b, c);
        }
    }
}