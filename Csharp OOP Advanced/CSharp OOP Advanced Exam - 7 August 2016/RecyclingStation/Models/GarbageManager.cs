using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models
{
    public class GarbageManager : IGarbageManager
    {
        private IGarbageProcessor garbageProcessor;
        private IWasteFactory wasteFactory;

        private double capitalBalance;
        private double energyBalance;

        private double minEnergyBalance;
        private double minCapitalBalance;
        private string requiredGarbageType;
        private bool requirementsAreSet;

        public GarbageManager(IGarbageProcessor garbageProcessor, IWasteFactory wasteFactory)
        {
            this.garbageProcessor = garbageProcessor;
            this.wasteFactory = wasteFactory;
        }

        public string ChangeManagementRequirement(double minEnergyBalance, double minCapitalBalance, string requiredGarbageType)
        {
            this.minEnergyBalance = minEnergyBalance;
            this.minCapitalBalance = minCapitalBalance;
            this.requiredGarbageType = requiredGarbageType;

            requirementsAreSet = true;

            return "Management requirement changed!";
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            if (this.requirementsAreSet)
            {
                bool requirementsAreSatisfied = true;

                if (this.requiredGarbageType == type)
                {
                    requirementsAreSatisfied = this.capitalBalance >= this.minCapitalBalance && this.energyBalance >= this.minEnergyBalance;
                }

                if (!requirementsAreSatisfied)
                {
                    return $"Processing Denied!";
                }
            }

            IWaste waste = this.wasteFactory.Create(name, weight, volumePerKg, type);

            IProcessingData processingData = this.garbageProcessor.ProcessWaste(waste);

            this.capitalBalance += processingData.CapitalBalance;
            this.energyBalance += processingData.EnergyBalance;

            return $"{waste.Weight:F2} kg of {waste.Name} successfully processed!";
        }

        public string Status()
        {
            return $"Energy: {energyBalance:F2} Capital: {capitalBalance:F2}";
        }
    }
}