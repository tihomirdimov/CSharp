namespace RecyclingStation.WasteDisposal.Models.Garbage
{
    class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double volumePerKg, double weight) : base(name, volumePerKg, weight)
        {
        }
    }
}