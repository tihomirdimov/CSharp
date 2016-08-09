using System;
class SumOfThreeNumbers
{
    static void Main()
    {
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c = float.Parse(Console.ReadLine());
        float sum = a + b + c;
        Console.WriteLine("{0}", sum);
    }
}
