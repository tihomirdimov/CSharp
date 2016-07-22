using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04EnumerationsAndAttributesProblem01
{
    public enum CardSuits
    {
        Clubs, Diamonds, Hearts, Spades,
    }

    class Startup
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Card Suits:");
            var suits = Enum.GetValues(typeof(CardSuits));
            foreach (var suit in suits)
            {
                Console.WriteLine("Ordinal value: {0}; Name value: {1}", (int)suit, suit);
            }
        }
    }
}
