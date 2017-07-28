using InfernoInfinity.Interfaces;

namespace InfernoInfinity.Models.Utils
{
    public class DmgBoost : IDmgBoost
    {
        public DmgBoost(int minDmgBoost, int maxDamageBoost)
        {
            this.MinDamageBoost = minDmgBoost;
            this.MaxDamageBoost = maxDamageBoost;
        }

        public int MinDamageBoost { get; private set; }
        public int MaxDamageBoost { get; private set; }
    }
}