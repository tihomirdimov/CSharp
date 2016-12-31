namespace RacingBoatSimulator.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Database;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models;
    using BoatRacingSimulator.Models.Boats;


    [TestClass]
    public class BoatSimulatorTests
    {
        [TestMethod]
        public void TestOpenRace()
        {
            //Arrange
            var testCommand = new BoatSimulatorController();

            //Act
            int distance = 100;
            int windSpeed = 10;
            int oceanCurrentSpeed = 5;
            bool allowsMotorboats = false;
            string commandResult = testCommand.OpenRace(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);

            //Assert
            string expectedResult = "A new race with distance 100 meters, wind speed 10 m/s and ocean current speed 5 m/s has been set.";
            Assert.AreEqual(expectedResult, commandResult, "Correct");
        }

        [TestMethod]
        public void TestStartRace()
        {
            //Arrange

            int distance = 100;
            int windSpeed = 10;
            int oceanCurrentSpeed = 5;
            bool allowsMotorboats = true;
            var race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);

            IBoat boat1 = new SailBoat("Sailor99", 600, 5);
            IBoat boat2 = new SailBoat("Oracle Wind Champion", 400, 2);
            IBoat boat3 = new SailBoat("BMW World Tourer", 900, 10);

            BoatSimulatorDatabase database = new BoatSimulatorDatabase();

            database.Boats.Add(boat1);
            database.Boats.Add(boat2);
            database.Boats.Add(boat3);

            var testController = new BoatSimulatorController(database, race);

            testController.SignUpBoat("Sailor99");
            testController.SignUpBoat("Oracle Wind Champion");
            testController.SignUpBoat("BMW World Tourer");

            //Act
            string commandResult = testController.StartRace();

            //Assert
            string expectedResult = "First place: SailBoat Model: BMW World Tourer Time: Did not finish!\r\nSecond place: SailBoat Model: Sailor99 Time: Did not finish!\r\nThird place: SailBoat Model: Oracle Wind Champion Time: Did not finish!\r\n";
            Assert.AreEqual(expectedResult, commandResult, "Correct");
        }
    }
}
