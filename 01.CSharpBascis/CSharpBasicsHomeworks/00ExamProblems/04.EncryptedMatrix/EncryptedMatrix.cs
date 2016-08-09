//points 90 from 100
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EncryptedMatrix
{
    static void Main()
    {
        string input = Console.ReadLine();
        string direction = Console.ReadLine();
        int[] inputToAscii = new int[input.Length];
        int[] lastAscii = new int[input.Length];
        int[] result = new int[lastAscii.Length];
        for (int i = 0; i < input.Length; i++)
        {
            inputToAscii[i] = (int)input[i];
            lastAscii[i] = inputToAscii[i] % 10;
            if (lastAscii[i] == 0 || lastAscii[i] % 2 == 0)
            {
                result[i] = lastAscii[i] * lastAscii[i];
            }
            else
            {
                if (i == 0)
                {
                    result[i] = lastAscii[i] + lastAscii[i + 1];
                }
                else if (i == lastAscii.Length - 1)
                {
                    result[i] = lastAscii[i] + lastAscii[i - 1];
                }
                else
                {
                    result[i] = lastAscii[i] + lastAscii[i - 1] + lastAscii[i + 1];
                }
            }
        }
        for (int i = 0; i < lastAscii.Length; i++)
        {
            if (lastAscii[i] == 0 || lastAscii[i] % 2 == 0)
            {
                result[i] = lastAscii[i] * lastAscii[i];
            }
            else
            {
                if (i == 0)
                {
                    result[i] = lastAscii[i] + lastAscii[i + 1];
                }
                else if (i == lastAscii.Length - 1)
                {
                    result[i] = lastAscii[i] + lastAscii[i - 1];
                }
                else
                {
                    result[i] = lastAscii[i] + lastAscii[i - 1] + lastAscii[i + 1];
                }
            }
        }
        List<int> diagonal = new List<int>();
        foreach (int number in result)
        {
            if (number > 9)
            {
                diagonal.Add(number / 10);
                diagonal.Add(number % 10);
            }
            else
            {
                diagonal.Add(number);
            }
        }
        int[,] matrix = new int[diagonal.Count, diagonal.Count];
        if (direction == "\\")
        {
            for (int i = 0; i < diagonal.Count; i++)
            {
                for (int j = 0; j < diagonal.Count; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = diagonal[i];
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        else if (direction == "/")
        {
            for (int i = diagonal.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < diagonal.Count; j++)
                {
                    if ((i + j) == (diagonal.Count - 1))
                    {
                        matrix[i, j] = diagonal[j];
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            for (int i = 0; i < diagonal.Count; i++)
            {
                for (int j = 0; j < diagonal.Count; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}