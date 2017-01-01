namespace RecyclingStation.Models.Garbage
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public abstract class Garbage : IWaste
    {
        public string Name { get; }
        public double VolumePerKg { get; }
        public double Weight { get; }
    }
}
