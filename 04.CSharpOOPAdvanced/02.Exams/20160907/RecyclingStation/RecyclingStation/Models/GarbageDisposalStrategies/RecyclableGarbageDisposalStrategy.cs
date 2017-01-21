namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class RecyclableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double garbageVolume = garbage.Weight * garbage.VolumePerKg;
            double energyUsed = 0.5 * garbageVolume;
            double capitalEarned = 400 * garbage.Weight;
            return new ProcessingData(0 - energyUsed, capitalEarned);
        }
    }
}
