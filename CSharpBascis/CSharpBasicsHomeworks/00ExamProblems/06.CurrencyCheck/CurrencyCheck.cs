// points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class CurrencyCheck
{
    static void Main(string[] args)
    {
        double r = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double m = double.Parse(Console.ReadLine());
        double[] values = new double[5];
        values[0] = (r / 100) * (3.5);
        values[1] = d * 1.5;
        values[2] = e * 1.95;
        values[3] = b / 2;
        values[4] = m;
        double bestValue = values.Min();
        Console.WriteLine("{0:0.00}", bestValue);
    }
}