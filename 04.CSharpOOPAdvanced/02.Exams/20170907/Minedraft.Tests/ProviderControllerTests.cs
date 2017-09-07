using System.Collections.Generic;
using Minedraft.Core.Controllers;
using Minedraft.Core.Repositories;
using NUnit.Framework;

public class ProviderControllerTests
{
    private ProviderController testController;

    [SetUp]
    public void TestInit()
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        this.testController = new ProviderController(energyRepository);
    }

    [Test]
    public void TestRegisterProduce()
    {
        testController.Register(new List<string>(new string[] { "Pressure", "40", "100" }));
        testController.Register(new List<string>(new string[] { "Solar", "20", "100" }));
        testController.Register(new List<string>(new string[] { "Standart", "30", "100" }));
        testController.Produce();
        Assert.AreEqual(400, this.testController.TotalEnergyProduced);
    }

    [Test]
    public void TestRegisterProduceEmpty()
    {
        testController.Register(new List<string>(new string[] { "Pressure", "40", "100" }));
        testController.Register(new List<string>(new string[] { "Solar", "20", "100" }));
        testController.Register(new List<string>(new string[] { "Standart", "30", "0" }));
        testController.Produce();
        Assert.AreEqual(300, this.testController.TotalEnergyProduced);
    }
}