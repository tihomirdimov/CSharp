using System;
class PointInACircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double R = 2;
        bool isInCircle = Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(R, 2);
        Console.WriteLine(isInCircle);
    }
}