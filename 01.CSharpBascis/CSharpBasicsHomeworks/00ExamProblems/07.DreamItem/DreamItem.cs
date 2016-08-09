//100 points from 100
using System;
using System.Globalization;
class DreamItem
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] values = input.Split('\\');
        string month = values[0];
        decimal wage = decimal.Parse(values[1], CultureInfo.InvariantCulture);
        decimal workHoursPerDay = decimal.Parse(values[2]);
        decimal itemPrice = decimal.Parse(values[3]);
        decimal workDays = 0;
        if (month == "Apr" || month == "June" || month == "Sept" || month == "Nov")
        {
            workDays = 30 - 10;
        }
        else if (month == "Feb")
        {
            workDays = 28 - 10;
        }
        else
        {
            workDays = 31 - 10;
        }
        decimal salary = workDays * workHoursPerDay * wage;
        decimal bonus = 0.1m;
        if (salary >= 700)
        {
            salary += (salary * bonus);
        }
        decimal difference = 0;
        if (salary >= itemPrice)
        {
            difference = salary - itemPrice;
            Console.WriteLine("Money left = {0:f2} leva.", difference);
        }
        if (salary < itemPrice)
        {
            difference = itemPrice - salary;
            Console.WriteLine("Not enough money. {0:f2} leva needed.", difference);
        }
    }
}