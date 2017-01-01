namespace RecyclingStation.Models
{
    using RecyclingStation.WasteDisposal.Interfaces;

    class ProcessingData:IProcessingData
    {
        public double EnergyBalance { get; }
        public double CapitalBalance { get; }
    }
}
