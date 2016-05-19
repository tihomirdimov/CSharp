using System;
class Rectangle
{
    static void Main()
    {
        double sideA= double.Parse(Console.ReadLine());
        double sideB = double.Parse(Console.ReadLine());
        double height = (sideA * 2) + (sideB * 2);
        double area = sideA * sideB;
        Console.WriteLine("Rectangle height is: {0}cm\nRectangle area is: {1}cm2", height, area);
    }
}