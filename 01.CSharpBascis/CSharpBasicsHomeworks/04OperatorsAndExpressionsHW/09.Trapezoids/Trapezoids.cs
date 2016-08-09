using System;
class Trapezoids
{
    static void Main()
    {
        double baseA = double.Parse(Console.ReadLine());
        double baseB = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        double area = (baseA + baseB)/2*height;
        Console.WriteLine("Trapezoid area is: {0} cm2", area);
    }
}