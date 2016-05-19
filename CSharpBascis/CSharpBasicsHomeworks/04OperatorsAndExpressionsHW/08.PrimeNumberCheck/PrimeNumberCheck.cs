using System;
class PrimeNumberCheck
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool isPrime = true;
        if (number > 100)
        {
            Console.WriteLine("Please enter number smaller than 100");
        }
        else
        {
            if (number <= 0 || number == 1)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= number-1; i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }
            Console.WriteLine(isPrime);
        }
    }
}