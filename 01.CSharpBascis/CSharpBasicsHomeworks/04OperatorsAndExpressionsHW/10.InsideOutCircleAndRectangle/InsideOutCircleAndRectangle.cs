using System;
class InsideOutCircleAndRectangle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double R = 1.5;
        bool isInCircle = Math.Pow(x-1, 2) + Math.Pow(y-1, 2) <= Math.Pow(R, 2);
        bool isOutsideRectangle = x < -1 || x > 5 || y < -1 || y > 1;
        Console.WriteLine("Is in Circle: {0}", isInCircle);
        Console.WriteLine("Is otside Rectangle: {0}", isOutsideRectangle);
        if (isInCircle == true && isOutsideRectangle == true)
        {
            Console.WriteLine("Answer: Yes");
        }
        else
        {
            Console.WriteLine("Answer: No");
        }
    }
}