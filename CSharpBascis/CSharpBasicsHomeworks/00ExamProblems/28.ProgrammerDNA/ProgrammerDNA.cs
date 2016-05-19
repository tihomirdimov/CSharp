//points 100 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28.ProgrammerDNA
{
    class ProgrammerDNA
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int charValue = char.Parse(Console.ReadLine());
            int counter = 1;
            for (int i = 1; i <= n; i++)
            {
                if (counter > 7)
                {
                    counter = 1;
                }
                switch (counter)
                {
                    case 1:
                        emptySpaceBuilder(3);
                        charValue = geneBuilder(charValue, 1);
                        emptySpaceBuilder(3);
                        counter++;
                        Console.WriteLine();
                        break;
                    case 2:
                        emptySpaceBuilder(2);
                        charValue = geneBuilder(charValue, 3);
                        emptySpaceBuilder(2);
                        counter++;
                        Console.WriteLine();
                        break;
                    case 3:
                        emptySpaceBuilder(1);
                        charValue = geneBuilder(charValue, 5);
                        emptySpaceBuilder(1);
                        counter++;
                        Console.WriteLine();
                        break;
                    case 4:
                        charValue = geneBuilder(charValue, 7);
                        counter++;
                        Console.WriteLine();
                        break;
                    case 5:
                        emptySpaceBuilder(1);
                        charValue = geneBuilder(charValue, 5);
                        emptySpaceBuilder(1);
                        counter++;
                        Console.WriteLine();
                        break;
                    case 6:
                        emptySpaceBuilder(2);
                        charValue = geneBuilder(charValue, 3);
                        emptySpaceBuilder(2);
                        counter++;
                        Console.WriteLine();
                        break;
                    case 7:
                        emptySpaceBuilder(3);
                        charValue = geneBuilder(charValue, 1);
                        emptySpaceBuilder(3);
                        counter++;
                        Console.WriteLine();
                        break;
                }
            }
        }
        static int geneBuilder(int currentChar, int repeatGene)

        {
            for (int i = 1; i <= repeatGene; i++)
            {
                if ((char)currentChar > 71)
                {
                    currentChar = 65;
                }
                Console.Write("{0}", (char)currentChar);
                currentChar++;
            }
            return currentChar;
        }
        static void emptySpaceBuilder(int emptySpaceBuild)
        {
            Console.Write(new string('.', emptySpaceBuild));
        }
    }
}