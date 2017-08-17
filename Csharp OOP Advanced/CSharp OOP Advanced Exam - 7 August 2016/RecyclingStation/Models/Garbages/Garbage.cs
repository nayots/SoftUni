using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Garbages
{
    public abstract class Garbage : IWaste
    {
        public Garbage(string name, double weight, double volumePerKg)
        {
            Name = name;
            Weight = weight;
            VolumePerKg = volumePerKg;
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public double VolumePerKg { get; set; }
    }
}