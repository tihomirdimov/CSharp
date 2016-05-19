using System;
class DivideBy7And5
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool isDividedBy5 = (number % 5 == 0);
        bool isDividedBy7 = (number % 7 == 0);
        if (isDividedBy5 == true && isDividedBy7 == true)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}