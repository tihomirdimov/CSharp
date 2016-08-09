using System;
using System.Globalization;
class BeerTime
{
    static void Main()
    {
        Console.WriteLine("Enter date in \"hh:mm tt\" format");
        DateTime checkTime;
        DateTime start = DateTime.Parse("01:00 PM");
        DateTime end = DateTime.Parse("03:00 AM");
        string timeString = Console.ReadLine();
        if (DateTime.TryParseExact(timeString, "hh:mm tt", new CultureInfo("en-US"), DateTimeStyles.None, out checkTime))
        {
            if (checkTime >= start || checkTime <= end)
            {
                Console.WriteLine("beer time");
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
        else
        {
            Console.WriteLine("Invalid time format");
        }
    }
}