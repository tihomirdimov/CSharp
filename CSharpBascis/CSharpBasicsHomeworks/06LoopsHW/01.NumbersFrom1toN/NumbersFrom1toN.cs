using System;
class NumbersFrom1toN
{
    static void Main()
    {
        Console.WriteLine("Please enter positive number");
        int number = int.Parse(Console.ReadLine());
        if (number <= 0)
        {
            Console.WriteLine("The number you entered is not a positive number");
        }
        else
        {
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}