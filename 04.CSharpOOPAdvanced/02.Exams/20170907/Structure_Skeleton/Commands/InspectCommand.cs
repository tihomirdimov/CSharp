using System.Collections.Generic;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.Inspect(Arguments);
    }
}