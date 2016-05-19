using System;
class NumberComparer
{
    static void Main()
    {
        Console.Write("Please enter a number: ");
        float a = float.Parse(Console.ReadLine());
        Console.Write("Please enter another number: ");
        float b = float.Parse(Console.ReadLine());
        Console.WriteLine("The greater number is {0}", Math.Max(a,b));
    }
}