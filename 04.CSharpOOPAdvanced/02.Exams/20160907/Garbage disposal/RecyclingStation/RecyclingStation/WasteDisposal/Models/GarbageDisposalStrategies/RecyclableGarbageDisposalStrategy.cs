using RecyclingStation.WasteDisposal.Interfaces;
namespace RecyclingStation.WasteDisposal.Models.GarbageDisposalStrategies
{
    public class RecyclableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double energyBalance = -0.5 * (garbage.Weight * garbage.VolumePerKg);
            double capitalBalance = 400 * garbage.Weight;
            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}
