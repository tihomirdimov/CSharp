using System;
class FormattingNumbers
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        string abin = Convert.ToString(a, 2).PadLeft(10, '0');
        Console.WriteLine("|{0,-10:X}|{1}|{2,10:0.##}|{3,-10:F3}|", a, abin, b, c);
    }
}