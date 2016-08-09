using System;
class FourDigitNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a four-digit number: ");
        int number = int.Parse(Console.ReadLine());
        if (number.ToString().Length == 4)
        {
            int d = number % 10;
            int c = (number / 10) % 10;
            int b = (number / 10 / 10) % 10;
            int a = (number / 10 / 10 / 10) % 10;
            Console.WriteLine("Sum of digits: {0}", a + b + c + d);
            Console.WriteLine("Reversed: {0}{1}{2}{3}", d, c, b, a);
            Console.WriteLine("Last digit in front {0}{1}{2}{3}", d, a, b, c);
            Console.WriteLine("Second and third digits exchanged {0}{1}{2}{3}", a, c, b, d);
        }
        else
        {
            Console.WriteLine("Entered number is not a four-digit number");
        }
    }
}
