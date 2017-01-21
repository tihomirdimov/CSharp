namespace RecyclingStation.Models
{
    using RecyclingStation.WasteDisposal.Interfaces;

    class ProcessingData : IProcessingData
    {
        private double energyBalance;
        private double capitalBalance;

        public ProcessingData(double energyBalance, double capitalBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }

        public double EnergyBalance { get; set; }
        public double CapitalBalance { get; set; }
    }
}
