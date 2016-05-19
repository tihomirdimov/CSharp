using System;
class SumOfMultipleNumbers
{
    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        double n = double.Parse(Console.ReadLine());
        double sum = 0;
        Console.WriteLine("Please enter value for each of the {0} numbers in the sequence", n);
        for (int i = 1; i <= n; i++)
        {
            double value = double.Parse(Console.ReadLine());
            sum += value;
        }
        Console.WriteLine("Sum of all numbers in the sequence is {0}: ", sum);
    }

}
