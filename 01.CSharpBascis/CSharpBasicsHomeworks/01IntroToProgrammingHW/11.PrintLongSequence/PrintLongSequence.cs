﻿using System;
class PrintLongSequence
{
        static void Main(string[] args)
        {
        int x = 2;
        int y = -3;
        for (int i = 1; i < 501; i++)
        {
            Console.Write(x + " " + y + " ");
            x = x + 2;
            y = y - 2;
        }
    }
}