using System;
class ThirdDigitIsSeven
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        string numberstr = number.ToString();
        char thirdDigit = numberstr[numberstr.Length - 3];
        if (thirdDigit == '7' ? true : false)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}