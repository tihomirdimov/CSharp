using System;
class FibonacciNumbers
{
    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        int n = int.Parse(Console.ReadLine());
        ulong n1 = 0;
        ulong n2 = 1;
        if (n == 1)
        {
            Console.Write("Please enter number greater than 0");
        }
        if (n == 1)
        {
            Console.Write(n1);
        }
        else
        {
            Console.Write("{0} ", n1);
            Console.Write("{0} ", n2);
            for (int i = 3; i <= n; i++)
            {
                ulong n3 = n1 + n2;
                //removing the space after the last number in the Fibonacci grid
                if (i < n)
                {
                    Console.Write("{0} ", n3);
                }
                else
                {
                    Console.Write("{0}", n3);
                }
                //change the values of the numbers in the grid
                n1 = n2;
                n2 = n3;
            }
        }

    }
}