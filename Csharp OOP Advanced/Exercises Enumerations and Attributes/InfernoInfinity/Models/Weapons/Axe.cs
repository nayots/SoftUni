using InfernoInfinity.Models.Gems;

namespace InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        public Axe(string weaponType, string rarity, string name) : base(weaponType, rarity, name)
        {
            this.MinDamage = 5;
            this.MaxDamage = 10;
            this.Sockets = new BaseGem[4];
            this.AddRarityBonuses();
        }
    }
}