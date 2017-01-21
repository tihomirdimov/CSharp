namespace RecyclingStation.Models.Garbage
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class Garbage : IWaste
    {
        private string name;
        private double weight;
        private double volumePerKg;
        public Garbage(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.Weight = weight;
            this.VolumePerKg = volumePerKg;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public double VolumePerKg { get; private set; }
    }
}
