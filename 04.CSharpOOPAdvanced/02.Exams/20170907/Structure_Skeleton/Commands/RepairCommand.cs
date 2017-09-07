using System.Collections.Generic;

public class RepairCommand: Command
{
    public RepairCommand(IList<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.Repair(Arguments);
    }
}
