using System;
using System.Linq;
class SumOfNumbers
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] numbersInLine = line.Split(' ');
        double[] numbers = Array.ConvertAll(numbersInLine, double.Parse);
        double sum = numbers.Sum();
        Console.WriteLine(sum);
    }
}
