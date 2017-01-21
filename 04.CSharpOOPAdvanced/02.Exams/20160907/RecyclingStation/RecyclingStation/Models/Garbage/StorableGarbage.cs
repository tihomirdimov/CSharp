namespace RecyclingStation.Models.Garbage
{
    using RecyclingStation.Attributes;

    [Storable]
    class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double weight, double volumePerKg) : base(name, weight, volumePerKg)
        {
        }
    }
}
