using RecyclingStation.WasteDisposal.Interfaces;
namespace RecyclingStation.WasteDisposal.Models.GarbageDisposalStrategies
{
    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public abstract IProcessingData ProcessGarbage(IWaste garbage);
    }
}