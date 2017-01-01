namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using System;
    using RecyclingStation.WasteDisposal.Interfaces;

    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            throw new NotImplementedException();
        }
    }
}
