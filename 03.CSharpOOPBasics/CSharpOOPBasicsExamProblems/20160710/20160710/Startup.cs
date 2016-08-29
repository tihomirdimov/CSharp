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
            string input = Console.ReadLine();
            bool isRunning = true;
            while (isRunning)
            {
                if (input.Equals("System Split"))
                {
                    CommandsEngine command = new CommandsEngine(input);
                    command.run();
                    isRunning = false;
                }
                input = Console.ReadLine();
            }
        }
    }
}
