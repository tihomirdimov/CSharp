using RecyclingStation.Models;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Core
{
    class BalanceManager
    {
        private double energy;
        private double capital;

        public BalanceManager()
        {
            this.Energy = 0;
            this.Capital = 0;
        }

        private double Energy { get; set; }
        private double Capital { get; set; }

        public void AddGabrage(IProcessingData garbage)
        {
            this.Energy += garbage.EnergyBalance;
            this.Capital += garbage.CapitalBalance;
        }

        public IProcessingData Status()
        {
            IProcessingData status = new ProcessingData(this.Energy, this.Capital);
            return status;
        }
    }
}