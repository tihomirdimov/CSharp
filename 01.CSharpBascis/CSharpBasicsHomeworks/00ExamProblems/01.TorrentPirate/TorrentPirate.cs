//points 70 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TorrentPirate
{
    class TorrentPirate
    {
        static void Main(string[] args)
        {
            double downloadVolume = int.Parse(Console.ReadLine());
            double ticketPrice = int.Parse(Console.ReadLine());
            double purchasingSpeed = int.Parse(Console.ReadLine());
            double numberOfMovies = downloadVolume / 1500;
            double costOfTickets = ticketPrice * numberOfMovies;
            double costOfPurchasing = ((downloadVolume / 2 / 60 / 60) * purchasingSpeed);
            if (costOfPurchasing <= costOfTickets)
            {
                Console.WriteLine("mall -> {0:0.00}lv", costOfPurchasing);
            }
            else
            {
                Console.WriteLine("cinema -> {0:0.00}lv", costOfTickets);
            }
        }
    }
}
