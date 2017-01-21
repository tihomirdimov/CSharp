namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double garbageVolume = garbage.Weight * garbage.VolumePerKg;
            double energyProduced = 0.8 * garbageVolume;
            return new ProcessingData (energyProduced, 0);
        }
    }
}
