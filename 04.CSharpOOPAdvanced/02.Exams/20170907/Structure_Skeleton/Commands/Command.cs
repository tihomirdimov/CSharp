using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected Command(IList<string> args, IManager manager)
    {
        this.Arguments = args;
        this.Manager = manager;
    }

    public IList<string> Arguments { get; private set; }

    public IManager Manager { get; private set; }

    public abstract string Execute();
}