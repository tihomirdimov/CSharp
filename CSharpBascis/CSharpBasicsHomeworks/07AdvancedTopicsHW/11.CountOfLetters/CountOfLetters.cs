using System;
using System.Collections.Generic;
using System.Linq;
class CountOfLetters
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        char[] letters = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            letters[i] = char.Parse(input[i]);
        }
        char[] alphabet = new char[26]
            {'a','b','c','d','e','f','g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n','o','p','q','e','s','t','u', 'v', 'w', 'x', 'y', 'z',};
        int counter = 0;
        for (int i = 0; i < alphabet.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (alphabet[i] == letters[j])
                {
                    counter++;
                }
                else
                {
                    continue;
                }
            }
            if (counter > 0)
            {
                Console.WriteLine("{0}->{1}", alphabet[i], counter);
                counter = 0;
            }
            else
            {
                continue;
            }
        }

    }
}