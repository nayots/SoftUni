namespace InfernoInfinity.Models.Gems
{
    public class Emerald : BaseGem
    {
        public Emerald(string clarity) : base(clarity)
        {
            this.StrengthBonus = 1;
            this.AgilityBonus = 4;
            this.VitalityBonus = 9;
            this.AddClarityBonuses();
        }
    }
}