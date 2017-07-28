using InfernoInfinity.Models.Enums;

namespace InfernoInfinity.Interfaces
{
    public interface IWeapon
    {
        int Agility { get; }
        int MaxDamage { get; }
        int MinDamage { get; }
        Rarity Rarity { get; }
        IBaseGem[] Sockets { get; }
        int Strength { get; }
        int Vitality { get; }
        string WeaponName { get; }
        WeaponType WeaponType { get; }

        void AddGem(int socketIndex, IBaseGem gem);

        void AddRarityBonuses();

        void RemoveGem(int socketIndex);

        string ToString();
    }
}