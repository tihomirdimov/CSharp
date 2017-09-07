using System.Collections.Generic;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.ShutDown();
    }
}
