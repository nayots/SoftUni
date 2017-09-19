using System;
using System.Collections.Generic;
using System.Linq;

public class SoldierFactory
{
    public SoldierFactory()
    {
    }

    public ISoldier CreateSoldier(string type, string name, int age, int experience, double endurance)
    {
        Type classType = Type.GetType(type);

        ISoldier soldier = (ISoldier)Activator.CreateInstance(classType, new object[] { name, age, experience, endurance });

        return soldier;
    }

    //name, age, experience, speed, endurance, motivation, maxWeight
    //public Soldier GenerateRanker(string name, int age, int experience, double speed, double endurance,
    //    double motivation, double maxWeight)
    //{
    //    return new Ranker(name, age, experience, endurance);
    //}

    //public Soldier GenerateCorporal(string name, int age, int experience, double speed, double endurance,
    //    double motivation, double maxWeight)
    //{
    //    return new Corporal(name, age, experience, endurance);
    //}

    //public Soldier GenerateSpecialForce(string name, int age, int experience, double speed, double endurance,
    //    double motivation, double maxWeight)
    //{
    //    return new SpecialForce(name, age, experience, endurance);
    //}

    //private bool WareHouseHasNeededWeapons(Soldier soldier)
    //{
    //    foreach (var weapon in soldier.WeaponsAllowed)
    //    {
    //        if (this.wareHouse.Weapons.ContainsKey(weapon))
    //        {
    //            if (this.wareHouse.Weapons[weapon])
    //            {
    //            }
    //        }

    //        return false;
    //    }
    //}
}