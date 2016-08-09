//points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.CompoundInterest
{
    class CompoundInterest
    {
        static void Main(string[] args)
        {
            double priceTV = double.Parse(Console.ReadLine());
            int term = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            double friendCommission = double.Parse(Console.ReadLine());
            double totalCostBank = priceTV * (Math.Pow(1 + interest, term));
            double totalCostFriend = priceTV * (1 + friendCommission);
            if (totalCostFriend <= totalCostBank)
                {
                Console.WriteLine("{0:f2} Friend",totalCostFriend);
                }
            else
                {
                Console.WriteLine("{0:f2} Bank",totalCostBank);
                }
        }
    }
}
