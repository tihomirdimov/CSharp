using System;
class RandomNumbersInGivenRange
{
    static void Main()
    {
        Console.WriteLine("Please enter a number");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter min value");
        int min = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter number for max value larget than min value");
        int max = int.Parse(Console.ReadLine());
        if (min <= max)
        {
            Random random = new Random();
            for (int i = 1; i <= n; i++)
            {
                int randomNumber = random.Next(min, max);
                Console.Write("{0} ", randomNumber);
            }
        }
        else
        {
            Console.WriteLine("Wrong input");
        }
    }
}