using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Strategies
{
    public class StorableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste garbage)
        {
            double capitalEarned = 0;
            double capitalUsed = garbage.CalculateWasteTotalVolume() * 0.65;
            return capitalEarned - capitalUsed;
        }

        protected override double CalculateEnergyBalance(IWaste garbage)
        {
            double energyProduced = 0;
            double energyUsed = garbage.CalculateWasteTotalVolume() * 0.13;

            return energyProduced - energyUsed;
        }
    }
}