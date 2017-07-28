using InfernoInfinity.Interfaces;
using InfernoInfinity.Models.Attributes;
using InfernoInfinity.Models.Enums;
using InfernoInfinity.Models.Utils;
using System;
using System.Linq;

namespace InfernoInfinity.Models.Weapons
{
    [WeaponAttribute("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        protected Weapon(string weaponType, string rarity, string name)
        {
            this.WeaponType = (WeaponType)Enum.Parse(typeof(WeaponType), weaponType);
            this.Rarity = (Rarity)Enum.Parse(typeof(Rarity), rarity);
            this.WeaponName = name;
        }

        public int Agility { get; protected set; }
        public int MaxDamage { get; protected set; }
        public int MinDamage { get; protected set; }
        public Rarity Rarity { get; protected set; }
        public IBaseGem[] Sockets { get; protected set; }
        public int Strength { get; protected set; }
        public int Vitality { get; protected set; }
        public string WeaponName { get; protected set; }
        public WeaponType WeaponType { get; protected set; }

        public void AddGem(int socketIndex, IBaseGem gem)
        {
            if (SocketExists(socketIndex))
            {
                this.Sockets[socketIndex] = gem;
            }
        }

        public void AddRarityBonuses()
        {
            this.MinDamage = (int)this.Rarity * this.MinDamage;
            this.MaxDamage = (int)this.Rarity * this.MaxDamage;
        }

        public void RemoveGem(int socketIndex)
        {
            if (SocketExists(socketIndex))
            {
                if (!SocketIsFree(socketIndex))
                {
                    this.Sockets[socketIndex] = null;
                }
            }
        }

        private bool SocketExists(int socketIndex)
        {
            if (socketIndex < 0 || socketIndex > this.Sockets.Length - 1)
            {
                return false;
            }
            return true;
        }

        private bool SocketIsFree(int socketIndex)
        {
            return this.Sockets[socketIndex] is null;
        }

        public override string ToString()
        {
            int minDamage = this.MinDamage;
            int maxDamage = this.MaxDamage;
            int strBonus = 0;
            int agiBonus = 0;
            int vitBonus = 0;

            foreach (var gem in this.Sockets.Where(s => s != null))
            {
                DmgBoost bonus = gem.CalculateDamageBoost();
                minDamage += bonus.MinDamageBoost;
                maxDamage += bonus.MaxDamageBoost;
                strBonus += gem.StrengthBonus;
                agiBonus += gem.AgilityBonus;
                vitBonus += gem.VitalityBonus;
            }

            return $"{this.WeaponName}: {minDamage}-{maxDamage} Damage, +{strBonus} Strength, +{agiBonus} Agility, +{vitBonus} Vitality";
        }
    }
}