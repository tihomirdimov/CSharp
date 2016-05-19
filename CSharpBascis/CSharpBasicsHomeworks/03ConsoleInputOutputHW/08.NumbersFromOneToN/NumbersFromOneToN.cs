using System;
class NumbersFromOneToN
{
    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("All numbers in the sequence:");
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }

}