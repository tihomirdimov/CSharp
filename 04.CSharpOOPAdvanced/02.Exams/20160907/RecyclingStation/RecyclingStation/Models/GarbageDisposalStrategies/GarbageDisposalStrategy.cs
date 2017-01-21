namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public abstract IProcessingData ProcessGarbage(IWaste garbage);
    }
}
