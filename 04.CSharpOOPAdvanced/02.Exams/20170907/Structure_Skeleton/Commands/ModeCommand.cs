using System.Collections.Generic;

public class ModeCommand : Command
{
    public ModeCommand(IList<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.Mode(Arguments);
    }
}