using RecyclingStation.Strategies;
using RecyclingStation.WasteDisposal.Attributes;

namespace RecyclingStation.Models.Garbages
{
    [RecyclableStrategy(typeof(RecyclableGarbageDisposalStrategy))]
    public class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double weight, double volumePerKg) : base(name, weight, volumePerKg)
        {
        }
    }
}