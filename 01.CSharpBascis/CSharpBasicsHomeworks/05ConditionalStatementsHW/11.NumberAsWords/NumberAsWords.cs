using System;
class NumberAsWords
{
    static void Main()
    {
        Console.WriteLine("Please enter an integer number [0..999] and press Enter.");
        int num = int.Parse(Console.ReadLine());
        int digit = num % 10;
        int tenth = (num / 10) % 10;
        int hundred = num / 100;
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "sventeen", "eightteen", "nineteen" };
        string[] tenths = { null, null, "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        string result;
        if (num == 0)
        {
            result = digits[0];
        }
        else if ((num >= 1) && (num <= 9))
        {
            result = digits[digit];
        }
        else if (num == 10)
        {
            result = teens[0];
        }
        else if ((num >= 11) && (num <= 19))
        {
            result = teens[digit];
        }
        else if ((num >= 20) && (num <= 99))
        {
            result = tenths[tenth] + " " + digits[digit];
        }
        else if ((num >= 100) && (num <= 999))
        {
            if (tenth == 0)
            {
                result = digits[hundred] + " hundred and " + digits[digit];
            }
            else if (tenth == 1)
            {
                result = digits[hundred] + " hundred and " + teens[digit];
            }
            else
            {
                result = digits[hundred] + " hundred and " + tenths[tenth] + " " + digits[digit];
            }
        }
        else
        {
            result = "Please enter number between 0 and 999";
        }
        string print = char.ToUpper(result[0]) + result.Substring(1);
        Console.WriteLine(print);
    }
}