using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter interpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter interpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.interpreter = interpreter;
    }

    public void Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            string input = reader.ReadLine();
            List<string> arguments = this.ParseInput(input);
            if (ShouldEnd(arguments[0]))
            {
                this.writer.WriteLine(this.interpreter.ProcessCommand(arguments));
                isRunning = false;
            }
            this.writer.WriteLine(this.interpreter.ProcessCommand(arguments));
        }
    }

    private List<string> ParseInput(string input)
    {
        return input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals(Constants.ShutDownInput);
    }
}
