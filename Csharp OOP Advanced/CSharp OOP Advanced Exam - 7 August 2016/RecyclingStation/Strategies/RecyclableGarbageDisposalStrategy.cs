using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Strategies
{
    public class RecyclableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            double capitalEarned = garbage.Weight * 400;
            return capitalEarned;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            double energyProduced = 0;
            double energyUsed = garbage.CalculateWasteTotalVolume() * 0.5;

            return energyProduced - energyUsed;
        }
    }
}