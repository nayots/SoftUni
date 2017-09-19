using System.Collections.Generic;

public interface IWareHouse
{
    Dictionary<IAmmunition, long> Weapons { get; }

    void EquipArmy(IArmy army);
}