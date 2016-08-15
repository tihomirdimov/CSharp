using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace _20160313Problem02
{
    class Monopoly
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int rows = dimensions[0];
            int money = 50;
            int hotels = 0;
            int turns = 0;
            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    int index;
                    if (i % 2 == 0)
                    {
                        index = j;
                    }
                    else
                    {
                        index = line.Length - j - 1;
                    }
                    switch (line[index])
                    {
                        case 'H':
                            hotels++;
                            Console.WriteLine("Bought a hotel for {0}. Total hotels: {1}.", money, hotels);
                            money = 0;
                            break;
                        case 'J':
                            Console.WriteLine("Gone to jail at turn {0}.", turns);
                            turns += 2;
                            money += 2 * hotels * 10;
                            break;
                        case 'S':
                            int columnIndex;
                            if (i % 2 == 0)
                            {
                                columnIndex = j;
                            }
                            else
                            {
                                columnIndex = index;
                            }
                            int moneyToSpend = Math.Min((columnIndex + 1) * (i + 1), money);
                            money -= moneyToSpend;
                            Console.WriteLine("Spent {0} money at the shop.", moneyToSpend);
                            break;
                    }
                    money += hotels * 10;
                    turns++;
                }
            }
            Console.WriteLine("Turns {0}", turns);
            Console.WriteLine("Money {0}", money);
        }
    }
}
