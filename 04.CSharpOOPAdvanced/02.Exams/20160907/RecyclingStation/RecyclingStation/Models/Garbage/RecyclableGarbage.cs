namespace RecyclingStation.Models.Garbage
{
    using RecyclingStation.Attributes;

    [Recyclable]
    class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double weight, double volumePerKg) : base(name, weight, volumePerKg)
        {
        }
    }
}
