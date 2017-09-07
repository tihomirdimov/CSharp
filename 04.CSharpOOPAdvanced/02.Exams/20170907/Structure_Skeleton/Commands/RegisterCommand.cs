using System.Collections.Generic;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.Register(Arguments);
    }
}