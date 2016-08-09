using System;
class PrintBDayAfter10Years
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your birthdate format yyyy/mm/dd and press enter");
        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
        DateTime dateToday = DateTime.Now;
        int age = dateToday.Year - dateOfBirth.Year;
        if (dateToday.Month < dateOfBirth.Month || (dateToday.Month == dateOfBirth.Month && dateToday.Day < dateOfBirth.Day))
        {
            age--;
        }
        Console.WriteLine("You are " + age + " years old.");
        Console.WriteLine("In 10 years you will be " + (age + 10) + " years old.");
    }
}
