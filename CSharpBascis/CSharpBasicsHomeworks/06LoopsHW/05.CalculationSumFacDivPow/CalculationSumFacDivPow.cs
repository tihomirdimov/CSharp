using System;
class CalculationSumFacDivPow
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter value for n");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter value for x");
        int x = int.Parse(Console.ReadLine());
        double factorial = 1;
        double result = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            result+= (factorial) / (Math.Pow(x, i));
        }
        Console.WriteLine("{0:f5}", result);
    }
}