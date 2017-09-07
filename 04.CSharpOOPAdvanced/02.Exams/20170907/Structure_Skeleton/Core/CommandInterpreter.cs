using System;
using System.Collections.Generic;
using Minedraft.Core.Controllers;
using Minedraft.Core.Repositories;

public class CommandInterpreter : ICommandInterpreter
{
    private IEnergyRepository energyRepo;
    private IOreRepository oreRepo;
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    private IManager manager;

    public CommandInterpreter()
    {
        this.energyRepo = new EnergyRepository();
        this.oreRepo = new OreRepository();
        this.harvesterController = new HarvesterController(energyRepo, oreRepo);
        this.providerController = new ProviderController(energyRepo);
        this.manager = new DraftManager();
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        string command = args[0];
        args.RemoveAt(0);

        Type commandType = Type.GetType(command + "Command");
        var constructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IManager) });
        ICommand cmd = (ICommand)constructor.Invoke(new object[]
        {
            args,
            this.manager,
        });
        return cmd.Execute();
    }
}