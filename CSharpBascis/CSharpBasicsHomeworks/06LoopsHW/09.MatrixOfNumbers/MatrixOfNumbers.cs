using System;
class MatrixOfNumbers
{
    static void Main()
    {
        Console.WriteLine("Please enter value for n");
        int n = int.Parse(Console.ReadLine());
        int counter = 1;
        if (n > 1 && n < 100)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n*2; j++)
                {
                    if (counter <= n)
                    {
                        Console.Write(j);
                        counter ++;
                    }
                }
                Console.WriteLine();
                counter = 1;
            }
        }
        else
        {
            Console.WriteLine("Wrong input");
        }
    }
}