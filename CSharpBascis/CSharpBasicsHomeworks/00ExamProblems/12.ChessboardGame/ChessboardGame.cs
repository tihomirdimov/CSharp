// points 60 from 100 runtime errors

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ChessboardGame
{
    class ChessboardGame
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int cellNum = n * n;
            int[] values = new int[cellNum];
            for (int i = 0; i < input.Length; i++)
            {
                values[i] = Convert.ToInt16(input[i]);
            }
            int blackTeamPoints = 0;
            int whiteTeamPoints = 0;
            //lower case - 97-122, upper case 65-90
            for (int i = 0; i < values.Length; i++)
            {
                if (!(((values[i] > 47) && (values[i] < 58)) ||
                     ((values[i] > 64) && (values[i] < 91)) ||
                     ((values[i] > 96) && (values[i] < 123))))
                    values[i] = 0;
            }
            int counter = 1;
            for (int i = 0; i < values.Length; i++)
            {
                if (counter % 2 != 0)
                {
                    if (values[i] > 64 && values[i] < 91)
                    {
                        whiteTeamPoints += values[i];
                    }
                    else
                    {
                        blackTeamPoints += values[i];
                    }
                }
                else
                {
                    if (values[i] > 64 && values[i] < 91)
                    {
                        blackTeamPoints += values[i];
                    }
                    else
                    {
                        whiteTeamPoints += values[i];
                    }
                }
                counter++;
            }
            int difference = 0;
            if (blackTeamPoints > whiteTeamPoints)
            {
                difference = blackTeamPoints - whiteTeamPoints;
                Console.WriteLine("The winner is: black team");
                Console.WriteLine(difference);
            }
            else if (blackTeamPoints == whiteTeamPoints)
            {
                Console.WriteLine("Equal result: {0}", blackTeamPoints);
            }
            else
            {
                difference = whiteTeamPoints - blackTeamPoints;
                Console.WriteLine("The winner is: white team");
                Console.WriteLine(difference);
            }
        }
    }
}
