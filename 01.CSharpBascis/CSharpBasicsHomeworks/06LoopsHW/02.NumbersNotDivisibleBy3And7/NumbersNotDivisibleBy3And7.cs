using System;
class NumbersNotDivisibleBy3And7
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
                if ((i % 3 == 0) || (i % 7 == 0))
                {
                    //continue;
                }
                else
                { 
                    Console.Write("{0} ", i);
                }
            }
        }
    }
}