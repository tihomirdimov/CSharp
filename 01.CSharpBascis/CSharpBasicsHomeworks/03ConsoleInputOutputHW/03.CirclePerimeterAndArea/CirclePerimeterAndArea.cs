using System;
class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("Please enter radius (r)");
        double radius = double.Parse(Console.ReadLine());
        double pi = Math.PI;
        double perimeter = 2*pi*radius;
        double area = pi*radius*radius;
        Console.WriteLine("Cirle perimeter: {0:0.##}\nCirle area: {1:0.##}", perimeter, area);
    }
}
