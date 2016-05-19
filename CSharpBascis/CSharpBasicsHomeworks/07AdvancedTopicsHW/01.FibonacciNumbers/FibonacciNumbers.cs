using System;
class FibonacciNumbers
{
    static int Fib(int n)
    {
        int firstNumber = 1;
        int secondNumber = 1;
        int thirdNumber = 1;
        for (int i = 2; i <= n; i++)
        {
            thirdNumber = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = thirdNumber;
        }
        return thirdNumber;
    }

    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        int number = int.Parse(Console.ReadLine());
        int fibNumber = 0;
        if (number == 0 || number == 1)
        {
            Console.WriteLine("Fib({0}) = 1", number);
        }
        else
        {
            fibNumber = Fib(number);
            Console.WriteLine("Fib({0}) = {1}", number, fibNumber);
        }
    }
}