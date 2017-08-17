using RecyclingStation.Strategies;
using RecyclingStation.WasteDisposal.Attributes;

namespace RecyclingStation.Models.Garbages
{
    [BurnableStrategy(typeof(BurnableGarbageDisposalStrategy))]
    public class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double weight, double volumePerKg) : base(name, weight, volumePerKg)
        {
        }
    }
}