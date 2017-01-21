namespace RecyclingStation.Core
{
    using System;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class Engine
    {
        private BalanceManager balanceManager;

        public Engine()
        {
            this.BalanceManager = new BalanceManager();
        }

        internal BalanceManager BalanceManager { get; set; }

        public void Run()
        {
            var input = Console.ReadLine();
            while (input != "TimeToRecycle")
            {
                if (input == "Status")
                {
                    var result = BalanceManager.Status();
                    Console.WriteLine("Energy:{0:F2} Capital:{1:F2}", result.EnergyBalance, result.CapitalBalance);
                }
                else
                {
                    try
                    {
                        CommandHandler processCommand = new CommandHandler();
                        IProcessingData processedGarbage = processCommand.Process(input);
                        BalanceManager.AddGabrage(processedGarbage);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
