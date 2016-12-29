using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.WasteDisposal.Models.GarbageDisposalStrategies
{
    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double energyBalance = 1 * (garbage.Weight * garbage.VolumePerKg) - 0.2 * (garbage.Weight * garbage.VolumePerKg);
            double capitalBalance = 0;
            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}
