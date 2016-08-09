using System;
using System.Collections.Generic;
using System.Linq;
class DifferenceBetweenDates
{
    static void Main()
    {
        Console.Write("Enter first date in (dd.MM.yyyy) format: ");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        firstDate.ToString("dd.MM.yyyy");
        Console.Write("Enter second date in (dd.MM.yyyy) format: ");
        DateTime secondDate = DateTime.Parse(Console.ReadLine());
        secondDate.ToString("dd.MM.yyyy");
        TimeSpan daysBetween = secondDate - firstDate;
        double days = daysBetween.TotalDays;
        Console.WriteLine(days);
    }
}