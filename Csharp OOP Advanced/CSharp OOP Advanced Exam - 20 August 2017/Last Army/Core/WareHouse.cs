using System.Collections.Generic;

public class WareHouse : IWareHouse
{
    public WareHouse()
    {
        this.Weapons = new Dictionary<IAmmunition, long>();
    }

    public Dictionary<IAmmunition, long> Weapons { get; private set; }

    public void EquipArmy(IArmy army)
    {
    }
}