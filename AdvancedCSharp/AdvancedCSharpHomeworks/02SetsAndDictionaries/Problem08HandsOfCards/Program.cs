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
                Console.WriteLine("{0}: ", player.Key);
                foreach (string card in player.Value)
                {
                    Console.Write(card);
                }
                Console.WriteLine();
                
            }
        }
        public static void addCards(string name, string cards)
        {
            HashSet<string> currentCards = new HashSet<string>(cards.Split(',').Select(item => item.Trim()).ToList());
            if (playerResults.ContainsKey(name))
            {
                HashSet<string> tempCards = playerResults[name];
                foreach (string currentCard in currentCards)
                {
                    tempCards.Add(currentCard);
                }
                playerResults.Add(name, tempCards);
            }
            else
            {
                playerResults.Add(name, currentCards);
            }
        }
        //public static int calculateCard(string card)
        //{
        //    int cardPower = 0;
        //    int cardColor = 0;
        //    if (card.Length == 3)
        //    {
        //        cardPower = int.Parse(card.Substring(0, 2));
        //        cardColor = cardToValue(card[card.Length - 1]);
        //    }
        //    else
        //    {
        //        cardPower = cardToValue(card[0]);
        //        cardColor = cardToValue(card[card.Length - 1]);
        //    }
        //    return cardPower * cardColor;
        //}
        //public static int cardToValue(char power)
        //{
        //    switch (power)
        //    {
        //        case 'J':
        //            return 11;
        //        case 'Q':
        //            return 12;
        //        case 'K':
        //            return 13;
        //        case 'A':
        //            return 14;
        //        case 'S':
        //            return 4;
        //        case 'H':
        //            return 3;
        //        case 'D':
        //            return 2;
        //        case 'C':
        //            return 1;
        //        default:
        //            return Convert.ToInt32(power);
        //    }
        //}
    }
}
//int cardrowvalue = 0;
//            foreach (string cardwithcolor in cardswithcolor)
//            {
//                int cardvalue = calculatecard(cardwithcolor);
//cardrowvalue += cardvalue;
//            }