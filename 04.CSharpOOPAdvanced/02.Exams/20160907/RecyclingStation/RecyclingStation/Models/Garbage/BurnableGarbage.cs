namespace RecyclingStation.Models.Garbage
{
    using RecyclingStation.Attributes;

    [Burnable]
    class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double weight, double volumePerKg) : base(name, weight, volumePerKg)
        {
        }
    }
}
