using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Data
{
    public class ProcessingData : IProcessingData
    {
        public ProcessingData(double energyBalance, double capitalBalance)
        {
            EnergyBalance = energyBalance;
            CapitalBalance = capitalBalance;
        }

        public double EnergyBalance { get; private set; }

        public double CapitalBalance { get; private set; }
    }
}