using InfernoInfinity.Interfaces;
using InfernoInfinity.Models.Weapons;
using System;
using System.Collections.Generic;

namespace InfernoInfinity.Core.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon Create(IList<string> tokens)
        {
            string weaponType = tokens[1];
            string rarity = tokens[0];
            string name = tokens[2];

            IWeapon weapon = null;

            switch (weaponType)
            {
                case "Axe":
                    weapon = new Axe(weaponType, rarity, name);
                    break;

                case "Knife":
                    weapon = new Knife(weaponType, rarity, name);
                    break;

                case "Sword":
                    weapon = new Sword(weaponType, rarity, name);
                    break;

                default:
                    throw new ArgumentException($"Invalid weapon type!");
            }

            return weapon;
        }
    }
}