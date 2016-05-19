using System;
using System.Linq;
class MinMaxSumAndAverageOfNumbers
{
    static void Main()
    {
        Console.WriteLine("Please enter positive number");
        int number = int.Parse(Console.ReadLine());
        double[] numbers = new double[number];
        for (int i = 0; i < number; i++)
        {
            numbers[i] = double.Parse(Console.ReadLine());
        }
        Console.WriteLine("min = {0}", numbers.Min());
        Console.WriteLine("max = {0}", numbers.Max());
        Console.WriteLine("sum = {0}", numbers.Sum());
        Console.WriteLine("avg = {0:0.00}", numbers.Average());
    }
}