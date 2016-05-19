using System;
class PrintADeckOf52Cards
{
    static void Main()
    {
        string[] suits = new string[4] { "♣", "♦", "♥", "♠" };
        string[] cards = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        for (int i = 0; i < cards.Length; i++)
        {
            for (int j = 0; j < suits.Length; j++)
            {
                switch (j)
                {
                    case 3:
                        Console.Write("{0}{1} \n", cards[i], suits[j]);
                        break;
                    default:
                        Console.Write("{0}{1} ", cards[i], suits[j]);
                        break;
                }
            }
        }
    }
}