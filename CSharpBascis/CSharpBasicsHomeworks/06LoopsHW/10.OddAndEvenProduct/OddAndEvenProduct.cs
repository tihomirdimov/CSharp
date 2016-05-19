using System;
class OddAndEvenProduct
{
    static void Main()
    {
        Console.WriteLine("Please enter numbers separated by space");
        string[] numbers = Console.ReadLine().Split();
        int sumOdd = 1;
        int sumEven = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i % 2 == 0)
            {
                sumOdd *= Convert.ToInt32(numbers[i]);
            }
            else
            {
                sumEven *= Convert.ToInt32(numbers[i]);
            }
        }
        if (sumEven == sumOdd)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product={0}", sumOdd);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product={0}", sumOdd);
            Console.WriteLine("even_product={0}", sumEven);
        }
    }
}