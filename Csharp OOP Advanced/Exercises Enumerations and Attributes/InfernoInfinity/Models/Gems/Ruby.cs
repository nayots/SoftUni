namespace InfernoInfinity.Models.Gems
{
    public class Ruby : BaseGem
    {
        public Ruby(string clarity) : base(clarity)
        {
            this.StrengthBonus = 7;
            this.AgilityBonus = 2;
            this.VitalityBonus = 5;
            this.AddClarityBonuses();
        }
    }
}