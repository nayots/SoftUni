using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Strategies
{
    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            double capitalEarned = 0;
            return capitalEarned;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            double energyProduced = garbage.CalculateWasteTotalVolume();
            double energyUsed = garbage.CalculateWasteTotalVolume() * 0.2;

            return energyProduced - energyUsed;
        }
    }
}