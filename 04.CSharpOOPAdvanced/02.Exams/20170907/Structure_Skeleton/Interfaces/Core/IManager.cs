using System.Collections.Generic;

public interface IManager
{
    string Register(IList<string> arguments);

    string RegisterHarvester(IList<string> arguments);

    string RegisterProvider(IList<string> arguments);

    string Mode(IList<string> arguments);

    string Inspect(IList<string> arguments);

    string Repair(IList<string> arguments);

    string Day();

    string ShutDown();
    
}