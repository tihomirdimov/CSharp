using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _20160710.Commands;
using _20160710.Models;

namespace _20160710
{
    class Startup
    {
        static void Main()
        {
            bool isRunning = true;
            string input = Console.ReadLine();
            while (isRunning)
            {
                CommandsEngine command = new CommandsEngine(input);
                command.run();
                if (input.Equals("System Split"))
                {
                    break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
