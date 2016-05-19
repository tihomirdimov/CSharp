using System;
class NumbersInInterval
{
    static void Main()
    {
        Console.WriteLine("Enter start number: ");
        int start = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter start end: ");
        int end = int.Parse(Console.ReadLine());
        if (start > end)
        {
            Console.WriteLine("End value is greater than start value. Please reastart the program");
        }
        else
        {
            int n = 0;
            for (int i = start; i <= end; i++)
            {
                if (i % 5 == 0)
                {
                    Console.Write(i + " ");
                    n++;
                }
            }
            if (n == 0)
            {
                
                Console.WriteLine("\nThere are no numbers divisible by 5 between {0} and {1}", start, end);
            }
            else
            {
                Console.WriteLine("\nThere are {0} numbers divisible by 5 between {1} and {2}", n, start, end);
            }
        }
    }
}