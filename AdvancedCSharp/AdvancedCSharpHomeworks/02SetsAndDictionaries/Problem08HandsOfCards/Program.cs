using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem08HandsOfCards
{
    class Program
    {
        public static Dictionary<string, HashSet<string>> playerResults = new Dictionary<string, HashSet<string>>();
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                string[] tempInput = input.Split(':');
                addCards(tempInput[0], tempInput[1]);
                input = Console.ReadLine();
            }
            foreach (KeyValuePair<string, HashSet<string>> player in playerResults)
            {
                int cardValues = 0;
                foreach (string card in player.Value)
                {
                    cardValues += calculateCard(card);
                }
                Console.Write("{0}: {1}\n", player.Key, cardValues);
            }
        }
        public static void addCards(string name, string cards)
        {
            HashSet<string> currentCards = new HashSet<string>(cards.Split(',').Select(item => item.Trim()).ToList());
            if (playerResults.ContainsKey(name))
            {
                foreach (string currentCard in currentCards)
                {
                    playerResults[name].Add(currentCard);
                }
            }
            else
            {
                playerResults.Add(name, currentCards);
            }
        }
        public static int calculateCard(string card)
        {
            int cardpower = 0;
            int cardcolor = 0;
            if (card.Length == 3)
            {
                cardpower = 10;
                cardcolor = cardToValue(card[card.Length - 1]);
            }
            else
            {
                cardpower = cardToValue(Char.ToUpper(card[0]));
                cardcolor = cardToValue(card[card.Length - 1]);
            }
            return cardpower * cardcolor;
        }
        public static int cardToValue(char power)
        {
            int result = 0;
            switch (power)
            {
                case 'J':
                    return 11;
                case 'Q':
                    return 12;
                case 'K':
                    return 13;
                case 'A':
                    return 14;
                case 'S':
                    return 4;
                case 'H':
                    return 3;
                case 'D':
                    return 2;
                case 'C':
                    return 1;
                default:
                    result = int.Parse(power.ToString());
                    return power;
            }
        }
    }
}