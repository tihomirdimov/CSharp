using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04EnumerationsAndAttributesProblem06
{
    public class Card
    {
        public Card(CardSuit suit, CardRank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
        public CardSuit Suit { get; set; }
        public CardRank Rank { get; set; }
        public int Power()
        {
            return (int)this.Rank + (int)this.Suit;
        }
        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power()}";
        }
    }
    [Type(Type = "Enumeration", Category = "Suit", Description = "Provides suit constants for a Card class.")]

    public enum CardSuit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }
    [Type(Type = "Enumeration", Category = "Rank", Description = "Provides rank constants for a Card class.")]
    public enum CardRank
    {

        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
    [AttributeUsage(AttributeTargets.Enum)]
    public class TypeAttribute : Attribute
    {
        public string Type { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Type = {this.Type}, Description = {this.Description}";
        }
    }
    class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            if (input.Equals("Rank"))
            {
                var attributes = typeof(CardRank).GetCustomAttributes(false);

                foreach (TypeAttribute attr in attributes)
                {
                    Console.WriteLine(attr);
                }
            }
            else
            {
                var attributes = typeof(CardSuit).GetCustomAttributes(false);

                foreach (TypeAttribute attr in attributes)
                {
                    Console.WriteLine(attr);
                }
            }
        }
    }
}
