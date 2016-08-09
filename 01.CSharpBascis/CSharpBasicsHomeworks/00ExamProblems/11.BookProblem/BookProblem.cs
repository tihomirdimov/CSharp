//points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.BookProblem
{
    class BookProblem
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int campingDays = int.Parse(Console.ReadLine());
            int pagesPerDay = int.Parse(Console.ReadLine());
            if (campingDays < 30)
            {
                decimal monthsToRead = Math.Ceiling((Convert.ToDecimal(pages) / ((30 - Convert.ToDecimal(campingDays)) * Convert.ToDecimal(pagesPerDay))));
                int totalYearsToRead = Convert.ToInt32(monthsToRead) / 12;
                decimal totalMonthsToRead = monthsToRead - totalYearsToRead * 12;
                Console.WriteLine("{0} years {1} months", totalYearsToRead, totalMonthsToRead);
            }
            else
            {
                Console.WriteLine("never");
            }
                
        }
    }
}
