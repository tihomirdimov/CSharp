using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04EnumerationsAndAttributesProblem03
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
    public enum CardSuit
    {
        Clubs = 0,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }
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
    class Startup
    {
        static void Main(string[] args)
        {
            var rank = (CardRank)Enum.Parse(typeof(CardRank), Console.ReadLine());
            var suit = (CardSuit)Enum.Parse(typeof(CardSuit), Console.ReadLine());
            Card card = new Card(suit, rank);
            Console.WriteLine(card);
        }
    }
}