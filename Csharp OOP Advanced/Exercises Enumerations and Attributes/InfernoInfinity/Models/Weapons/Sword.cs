using InfernoInfinity.Models.Gems;

namespace InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        public Sword(string weaponType, string rarity, string name) : base(weaponType, rarity, name)
        {
            this.MinDamage = 4;
            this.MaxDamage = 6;
            this.Sockets = new BaseGem[3];
            this.AddRarityBonuses();
        }
    }
}