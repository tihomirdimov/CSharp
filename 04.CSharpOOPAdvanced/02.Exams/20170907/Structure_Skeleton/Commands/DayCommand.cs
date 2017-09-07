using System.Collections.Generic;

public class DayCommand : Command
{
    public DayCommand(IList<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.Day();
    }
}