﻿using System;
using System.IO;

namespace PizzaMore.Utility
{
    public static class Logger
    {
        public static void Log(string message)
        {
            File.AppendAllText("log.txt", message + Environment.NewLine);
        }
    }
}
