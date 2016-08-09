//За стойности a=-1,b=3,c=0	резултатите за x1=3; x2=0 са сменени в отговора на условието;
using System;
class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Solving quadratic equations: ax^2 + bx + c = 0");
        Console.WriteLine("Enter value for a");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value for b"); ;
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value for c");
        double c = double.Parse(Console.ReadLine());
        double D = b * b - 4 * a * c;
        Console.WriteLine("Determinant value is {0}", D);
        if (D < 0)
        {
            Console.WriteLine("Equation has no real roots");
        }
        if (D == 0)
        {
            double negativeb = b * -1;
            double x = negativeb /(2*a);
            Console.WriteLine("Equation has one real root: {0}", x);

        }
        if (D > 0)
        {
            double negativeb = b * -1;
            double x1 = (negativeb+Math.Sqrt(D))/(2*a);
            double x2 = (negativeb-Math.Sqrt(D))/(2*a);
            Console.WriteLine("Equation has two real roots: x1={0}; x2={1}", x1,x2);
        }
    }
}