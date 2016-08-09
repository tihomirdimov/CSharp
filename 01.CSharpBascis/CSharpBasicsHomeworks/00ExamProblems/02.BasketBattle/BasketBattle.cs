//points 70 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BasketBattle
{
    class BasketBattle
    {
        static void Main(string[] args)
        {
            string setFirstPlayer = Console.ReadLine();
            string[] players = new string[2] { "Nakov", "Simeon" };
            string firstPlayer = null;
            string secondPlayer = null;
            if (setFirstPlayer == players[0])
            {
                firstPlayer = players[0];
                secondPlayer = players[1];
            }
            else
            {
                firstPlayer = players[1];
                secondPlayer = players[0];
            }
            bool isFirstPlayer = true;
            int rounds = int.Parse(Console.ReadLine());
            int strikes = 1;
            int pointsFirstPlayer = 0;
            int pointsSecondPlayer = 0;
            int currentRoundPoints = 0;
            bool ifWin = false;
            string currentRoundResult = null;
            double realRound = 0;
            for (int i = 1; i <= rounds * 2; i++)
            {
                realRound = i / 2;
                Math.Ceiling(realRound);
                if (strikes < 2 && isFirstPlayer == true)
                {
                    currentRoundPoints = int.Parse(Console.ReadLine());
                    currentRoundResult = Console.ReadLine();
                    if (currentRoundResult == "success" && (pointsFirstPlayer + currentRoundPoints) <= 500)
                    {
                        pointsFirstPlayer += currentRoundPoints;
                        if (pointsFirstPlayer == 500)
                        {
                            Console.WriteLine(firstPlayer);
                            Console.WriteLine(realRound);
                            Console.WriteLine(pointsSecondPlayer);
                            ifWin = true;
                            break;
                        }
                    }
                    strikes++;
                }
                else if (strikes >= 2 && isFirstPlayer == true)
                {
                    strikes = 0;
                    isFirstPlayer = false;
                    currentRoundPoints = int.Parse(Console.ReadLine());
                    currentRoundResult = Console.ReadLine();
                    if (currentRoundResult == "success" && (pointsSecondPlayer + currentRoundPoints) <= 500)
                    {
                        pointsSecondPlayer += currentRoundPoints;
                        if (pointsSecondPlayer == 500)
                        {
                            Console.WriteLine(secondPlayer);
                            Console.WriteLine(realRound);
                            Console.WriteLine(pointsFirstPlayer);
                            ifWin = true;
                            break;
                        }
                    }
                    strikes++;
                }
                else if (strikes < 2 && isFirstPlayer == false)
                {
                    currentRoundPoints = int.Parse(Console.ReadLine());
                    currentRoundResult = Console.ReadLine();
                    if (currentRoundResult == "success" && (pointsSecondPlayer + currentRoundPoints) <= 500)
                    {
                        pointsSecondPlayer += currentRoundPoints;
                        if (pointsSecondPlayer == 500)
                        {
                            Console.WriteLine(secondPlayer);
                            Console.WriteLine(realRound);
                            Console.WriteLine(pointsFirstPlayer);
                            ifWin = true;
                            break;
                        }
                    }
                    strikes++;
                }
                else if (strikes >= 2 && isFirstPlayer == false)
                {
                    strikes = 0;
                    isFirstPlayer = true;
                    currentRoundPoints = int.Parse(Console.ReadLine());
                    currentRoundResult = Console.ReadLine();
                    if (currentRoundResult == "success" && (pointsFirstPlayer + currentRoundPoints) <= 500)
                    {
                        pointsFirstPlayer += currentRoundPoints;
                        if (pointsFirstPlayer == 500)
                        {
                            Console.WriteLine(firstPlayer);
                            Console.WriteLine(realRound);
                            Console.WriteLine(pointsSecondPlayer);
                            ifWin = true;
                            break;
                        }
                    }
                    strikes++;
                }
            }
            if (ifWin == false)
            {
                if (pointsFirstPlayer > pointsSecondPlayer)
                {
                    Console.WriteLine(firstPlayer);
                    Console.WriteLine(pointsFirstPlayer - pointsSecondPlayer);
                }
                else if (pointsFirstPlayer == pointsSecondPlayer)
                {
                    Console.WriteLine("DRAW");
                    Console.WriteLine(pointsFirstPlayer);
                }
                else
                {
                    Console.WriteLine(secondPlayer);
                    Console.WriteLine(pointsSecondPlayer - pointsFirstPlayer);
                }
            }
        }
    }
}