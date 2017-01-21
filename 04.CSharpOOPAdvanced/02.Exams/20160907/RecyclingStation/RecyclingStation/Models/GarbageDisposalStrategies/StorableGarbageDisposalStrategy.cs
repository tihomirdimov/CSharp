namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class StorableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double garbageVolume = garbage.Weight * garbage.VolumePerKg;
            double energyUsed = 0.13 * garbageVolume;
            double capitalUsed = 0.65 * garbageVolume;
            return new ProcessingData(0 - energyUsed, 0 - capitalUsed);
        }
    }
}
