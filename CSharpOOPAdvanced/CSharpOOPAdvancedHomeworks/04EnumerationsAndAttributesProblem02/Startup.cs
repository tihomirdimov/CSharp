using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04EnumerationsAndAttributesProblem01
{
    public enum CardRanks
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King,
    }
    class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Card Ranks:");
            var suits = Enum.GetValues(typeof(CardRanks));
            foreach (var suit in suits)
            {
                Console.WriteLine("Ordinal value: {0}; Name value: {1}", (int)suit, suit);
            }
        }
    }
}