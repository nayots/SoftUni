using System.Collections.Generic;

public class AmmunitionsController
{
    private List<string> weaponsForRemoval = new List<string>();

    public void DecreaseAmmunitionsWearLevel(Mission mission, Dictionary<string, List<Ammunition>> wearHouse)
    {
        string weaponName = string.Empty;

        //foreach (var weapon in mission.MissionWeapons)
        //{
        //    weaponName = weapon.Name;
        //    foreach (var ammunition in wearHouse[weaponName])
        //    {
        //        if (weaponName.Equals(ammunition.Name))
        //        {
        //            ammunition.DecreaseWearLevel(mission.WearLevelDecrement);
        //        }
        //    }
        //}
    }

    public void ThrowAnyWeaponsWithZeroWearLevel(Dictionary<string, List<Ammunition>> wearHouse)
    {
        foreach (var type in wearHouse)
        {
            foreach (var weapon in type.Value)
            {
                //if (weapon.WearLevelIsZero)
                //{
                //    weaponsForRemoval.Add(type.Key);
                //}
            }
        }

        for (int i = 0; i < weaponsForRemoval.Count; i++)
        {
            wearHouse.Remove(weaponsForRemoval[i]);
        }
        weaponsForRemoval.Clear();
    }
}