namespace RecyclingStation.WasteDisposal.Models.Garbage
{
    public class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double volumePerKg, double weight) : base(name, volumePerKg, weight)
        {
        }
    }
}
