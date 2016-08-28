using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20160825.Commands;

namespace _20160825
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (true)
            {
                var command = new CommandsEngine(input);
                command.ReadCommand();
                if(input.Equals("Paw Paw Pawah"))
                {
                    break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
