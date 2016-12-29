using RecyclingStation.WasteDisposal.Interfaces;
namespace RecyclingStation.WasteDisposal.Models.GarbageDisposalStrategies
{
    class StorableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double energyBalance = -0.13 * (garbage.Weight * garbage.VolumePerKg);
            double capitalBalance = -0.65 * (garbage.Weight * garbage.VolumePerKg);
            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}