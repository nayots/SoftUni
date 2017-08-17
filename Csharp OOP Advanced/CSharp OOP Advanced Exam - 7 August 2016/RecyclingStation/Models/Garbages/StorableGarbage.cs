using RecyclingStation.Strategies;
using RecyclingStation.WasteDisposal.Attributes;

namespace RecyclingStation.Models.Garbages
{
    [StorableStrategy(typeof(StorableGarbageDisposalStrategy))]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double weight, double volumePerKg) : base(name, weight, volumePerKg)
        {
        }
    }
}