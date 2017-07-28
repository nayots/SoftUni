using InfernoInfinity.Models.Gems;

namespace InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        public Knife(string weaponType, string rarity, string name) : base(weaponType, rarity, name)
        {
            this.MinDamage = 3;
            this.MaxDamage = 4;
            this.Sockets = new BaseGem[2];
            this.AddRarityBonuses();
        }
    }
}