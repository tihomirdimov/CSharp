using System;
using System.Collections.Generic;
using System.Linq;
class MatrixOfPalindromes
{
    static void Main()
    {

        Console.WriteLine("Please enter a number for columns: ");
        int columnsNum = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter a number for columns: ");
        int rowsNum = int.Parse(Console.ReadLine());
        string[,] matrix = new string[columnsNum, rowsNum];
        char initialChar = 'a';
        for (char i = 'a'; i <= initialChar + columnsNum - 1; i++)
        {
            for (char j = i; j < i + rowsNum; j++)
            {
                string letters = i.ToString() + j.ToString() + i.ToString();
                Console.Write("{0} ", letters);
            }
            Console.WriteLine();
        }
    }
}