using System;
using RecyclingStation.WasteDisposal.Interfaces;
namespace RecyclingStation.WasteDisposal.Models
{
    public class RecyclingStation : IProcessingData
    {
        public RecyclingStation()
        {
            this.EnergyBalance = 0;
            this.CapitalBalance = 0;
        }
        public double EnergyBalance { get; set; }
        public double CapitalBalance { get; set; }

        public void SetBalance(IProcessingData balance)
        {
            this.EnergyBalance += balance.EnergyBalance;
            this.CapitalBalance += balance.CapitalBalance;
        }
        public void GetStatus()
        {
            Console.WriteLine("Energy: {0:F2} Capital: {1:F2}", this.EnergyBalance, this.CapitalBalance);
        }
    }
}